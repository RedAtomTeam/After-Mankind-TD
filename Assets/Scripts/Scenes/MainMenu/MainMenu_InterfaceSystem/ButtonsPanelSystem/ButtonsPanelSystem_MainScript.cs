using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPanelSystem_MainScript : MonoBehaviour
{
    // ����������:
    [SerializeField] private MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // ������� ����������.


    // ����������:


    // ���������� ����������:
    [SerializeField] private GameObject Buttons_Obj;            // ������. 
    [SerializeField] private List<string> techNameList = new List<string>();    // ������ ����������.
    [SerializeField] private List<string> levelNameList = new List<string>();   // ������ �������.

    // ������� ������� ����� ����.
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

    // ������� �������� ������.
    public void Open()
    {
        Buttons_Obj.SetActive(true);
    }

    // ������� �������� ������.
    public void Close()
    {
        Buttons_Obj.SetActive(false);
    }

    // ������� �������� �����.
    public void LoadScene(string sceneName)
    {
        mainMenuInterfaceSystem_MainScript.LoadScene(sceneName);
    }

    // ������� �������� ����� ����� ����������.
    public void GeneralTechnologySceneOpen()
    {
        mainMenuInterfaceSystem_MainScript.GeneralTechnologyOpen();
    }
}
