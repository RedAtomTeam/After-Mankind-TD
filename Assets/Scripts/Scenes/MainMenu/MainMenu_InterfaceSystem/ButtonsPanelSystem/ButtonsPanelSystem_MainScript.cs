using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPanelSystem_MainScript : MonoBehaviour
{
    private GameManager gameManager;

    // ����������:
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // ������� ����������.


    // ����������:


    // ���������� ����������:
    [SerializeField] GameObject Buttons_Obj;  // ������. 

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    // ������� ������� ����� ����.
    public void NewGameStart()
    {
        gameManager.Initialized();
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
