using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPanelSystem_MainScript : MonoBehaviour
{
    // Надсистемы:
    [SerializeField] private MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // Система интерфейса.


    // Подсистемы:


    // Внутренние переменные:
    [SerializeField] private GameObject Buttons_Obj;            // Объект. 
    [SerializeField] private List<string> techNameList = new List<string>();    // Список технологий.
    [SerializeField] private List<string> levelNameList = new List<string>();   // Список уровней.

    // Функция запуска новой игры.
    public void NewGameStart()
    {



        //foreach (string techName in techNameList)
        //{
        //    PlayerPrefs.SetInt(techName, 0);
        //}

        //foreach (string levelName in levelNameList)
        //{
        //    PlayerPrefs.SetInt($"{levelName}_Status", 0);
        //    PlayerPrefs.SetString($"{levelName}_Time", "00:00:0000");
        //    PlayerPrefs.SetString($"{levelName}_Defence", "00");

        //}
        //PlayerPrefs.SetInt($"{levelNameList[0]}_Status", 1);

        //PlayerPrefs.SetInt("techBalance", 400);

        //mainMenuInterfaceSystem_MainScript.LoadScene("GameMenu");
    }

    // Функция открытия панели.
    public void Open()
    {
        Buttons_Obj.SetActive(true);
    }

    // Функция закрытия панели.
    public void Close()
    {
        Buttons_Obj.SetActive(false);
    }

    // Функция загрузки сцены.
    public void LoadScene(string sceneName)
    {
        mainMenuInterfaceSystem_MainScript.LoadScene(sceneName);
    }

    // Функция загрузки сцены общих технологий.
    public void GeneralTechnologySceneOpen()
    {
        mainMenuInterfaceSystem_MainScript.GeneralTechnologyOpen();
    }
}
