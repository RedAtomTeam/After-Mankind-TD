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
            playerGameData.levels[i].status = 0;
        }
        for (int i = 0; i < allTechnologiesEntities.Length; i++)
        {
            technologiesData.Add(allTechnologiesEntities[i].ID, 0);

            playerGameData.technologies[i].ID = allTechnologiesEntities[i].ID;
            playerGameData.technologies[i].level = 0;
            playerGameData.technologies[i].status = 0;
        }
    }

    public void SaveGame(string fileName)
    {
        string saveFilePath = Application.persistentDataPath + fileName;
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(saveFilePath, FileMode.Create))
        {
            formatter.Serialize(stream, playerGameData);
        }
        Debug.Log("Игра сохранена.");
    }

    public void LoadGame(string fileName)
    {
        string saveFilePath = Application.persistentDataPath + fileName;
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
}


[System.Serializable]
public class BalanceData
{
    public float Balance;
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
public class GameData
{
    public BalanceData balanceData;
    public LevelData[] levels;
    public TechnologyData[] technologies;

    public GameData(int levelsCount, int technologiesCount)
    {
        balanceData = new BalanceData();
        balanceData.Balance = 0;


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
    }
}