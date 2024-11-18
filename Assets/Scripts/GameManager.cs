using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Статическая переменная для доступа

    Level[] allLevelsEntities;
    Technology[] allTechnologiesEntities;

    private Dictionary<int, int> levelsData = new Dictionary<int, int>();
    private Dictionary<int, int> technologiesData = new Dictionary<int, int>();

    public GameData playerGameData;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Сохраняем единственный экземпляр
            DontDestroyOnLoad(gameObject); // Не уничтожать при переходе между сценами
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликат
        }

        allLevelsEntities = Resources.LoadAll<Level>("");
        allTechnologiesEntities = Resources.LoadAll<Technology>("");

        playerGameData = new GameData(allLevelsEntities.Length, allTechnologiesEntities.Length);


        for (int i = 0; i < allLevelsEntities.Length; i++) 
        {
            levelsData.Add(allLevelsEntities[i].ID, 0);

            playerGameData.levels[i].ID = allLevelsEntities[i].ID;
            playerGameData.levels[i].status = allLevelsEntities[i].status;
        }
        for (int i = 0; i < allTechnologiesEntities.Length; i++)
        {
            technologiesData.Add(allTechnologiesEntities[i].ID, 0);

            playerGameData.technologies[i].ID = allTechnologiesEntities[i].ID;
            playerGameData.technologies[i].level = allTechnologiesEntities[i].level;
            playerGameData.technologies[i].status = allTechnologiesEntities[i].status;
        }
    }

    public void SaveGame(string fileName)
    {
        DateTime dataEndTimeNow = DateTime.Now;

        playerGameData.dateAndTimeData.day = dataEndTimeNow.Day;
        playerGameData.dateAndTimeData.month = dataEndTimeNow.Month;
        playerGameData.dateAndTimeData.year = dataEndTimeNow.Year;

        playerGameData.dateAndTimeData.seconds = dataEndTimeNow.Second;
        playerGameData.dateAndTimeData.minutes = dataEndTimeNow.Minute;
        playerGameData.dateAndTimeData.hours = dataEndTimeNow.Hour;

        string saveFilePath = Application.persistentDataPath + "\\" + fileName;
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(saveFilePath, FileMode.Create))
        {
            formatter.Serialize(stream, playerGameData);
        }
        Debug.Log("Игра сохранена.");
    }

    public void LoadGame(string fileName)
    {
        string saveFilePath = Application.persistentDataPath + "\\" + fileName;
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(saveFilePath, FileMode.Open))
            {
                playerGameData = formatter.Deserialize(stream) as GameData;
            }
            Debug.Log("Игра загружена.");
        }
    }

    public void FullUpdateTechnologyData()
    {
        foreach (TechnologyData technology in playerGameData.technologies)
        {
            int minPrev = 3;

            foreach (Technology techEnt in allTechnologiesEntities)
            {
                if (techEnt.ID == technology.ID)
                {
                    foreach (Technology prevTechEnt in techEnt.prevTech)
                    {
                        foreach (TechnologyData technologyPrev in playerGameData.technologies)
                        {
                            if (prevTechEnt.ID == technologyPrev.ID)
                            {
                                minPrev = minPrev < technologyPrev.status ? minPrev : technologyPrev.status;
                            }
                        }
                    }

                    minPrev -= 1; 
                    minPrev = minPrev < technology.status ? technology.status : minPrev;

                    technology.status = minPrev;

                }
            }
        }
    }

    public void FullUpdateLevelMapData()
    {
        foreach (LevelData level in playerGameData.levels)
        {
            int maxPrev = 0;

            foreach (Level levelEnt in allLevelsEntities)
            {
                if (levelEnt.ID == level.ID)
                {
                    foreach (Level nbLevelEnt in levelEnt.levels)
                    {
                        foreach (LevelData levelNb in playerGameData.levels)
                        {
                            if (nbLevelEnt.ID == levelNb.ID)
                            {
                                if (levelNb.status == 2)
                                {
                                    maxPrev = 1;
                                }
                            }
                        }
                    }
                    if (maxPrev == 2)
                    {
                        if (level.status < 1)
                        {
                            level.status = maxPrev;
                        }
                    }
                } 
            }
        }
    }
}

[System.Serializable]
public class DateAndTimeData
{
    public int day;
    public int month;
    public int year;

    public int seconds;
    public int minutes;
    public int hours;
}

[System.Serializable]
public class BalanceData
{
    public int Balance;
}

[System.Serializable]
public class LevelData
{
    public int ID;
    public int status;
}

[System.Serializable]
public class TechnologyData
{
    public int ID;
    public int level;
    public int status;
}

[System.Serializable]
public class Flags
{
    public Dictionary<string, bool> flags;
}

[System.Serializable]
public class GameData
{
    public BalanceData balanceData;
    public LevelData[] levels;
    public TechnologyData[] technologies;
    public Flags flags;
    public DateAndTimeData dateAndTimeData;

    public GameData(int levelsCount, int technologiesCount)
    {
        balanceData = new BalanceData();
        balanceData.Balance = 1000;

        levels = new LevelData[levelsCount];
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = new LevelData();
        }

        technologies = new TechnologyData[technologiesCount];
        for (int i = 0; i < technologies.Length; i++)
        {
            technologies[i] = new TechnologyData();
        }

        flags = new Flags();
        dateAndTimeData = new DateAndTimeData();
    }
}