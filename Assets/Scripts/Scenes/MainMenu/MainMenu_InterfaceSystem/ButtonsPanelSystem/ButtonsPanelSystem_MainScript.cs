using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPanelSystem_MainScript : MonoBehaviour
{
    // ����������:
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // ������� ����������.


    // ����������:


    // ���������� ����������:
    [SerializeField] GameObject Buttons_Obj;  // ������. 

    // ������� ������� ����� ����.
    public void NewGameStart()
    {
        LoadScene("GameMenu");
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
