using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPanelSystem_MainScript : MonoBehaviour
{
    // Надсистемы:
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // Система интерфейса.


    // Подсистемы:


    // Внутренние переменные:
    [SerializeField] GameObject Buttons_Obj;  // Объект. 

    // Функция запуска новой игры.
    public void NewGameStart()
    {
        LoadScene("GameMenu");
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
