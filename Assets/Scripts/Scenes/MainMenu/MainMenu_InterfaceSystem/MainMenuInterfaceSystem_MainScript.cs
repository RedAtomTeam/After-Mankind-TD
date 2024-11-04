using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInterfaceSystem_MainScript : MonoBehaviour
{
    // ����������:
    [SerializeField] MainMenuController mainMenuController;

    // ����������:
    [SerializeField] private ButtonsPanelSystem_MainScript buttonsPanelSystem_MainScript;   // ������� ������ ������.
    [SerializeField] private SettingsSystem_MainScript settingsSystem_MainScript;           // ������� ���� ��������.
    [SerializeField] private SavesSystem_MainScript savesSystem_MainScript;                 // ������� ���� ����������

    // ������� ���������� ���������.
    public void UpdateSoundsVolume()
    {
        mainMenuController.SetVolumeOfSoundEffects();
        mainMenuController.SetVolumeOfSoundtracks();
    }

    // ������� ��������� ��������� ������.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        mainMenuController.SetVolumeOfSoundtracks(soundtracks);
    }

    // ������� ��������� ��������� ������.
    public void SetVolumeOfSoundtracks()
    {
        mainMenuController.SetVolumeOfSoundtracks();
    }

    // ������� ��������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        mainMenuController.SetVolumeOfSoundEffects(soundEffects);
    }

    // ������� ��������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects()
    {
        mainMenuController.SetVolumeOfSoundEffects();
    }

    // ������� �������� �����.
    public void LoadScene(string sceneName)
    {
        mainMenuController.LoadScene(sceneName);
    }

    // ������� �������� ������ ������.
    public void OpenButtons()
    {
        buttonsPanelSystem_MainScript.Open();
    }

    // ������� �������� ������ ������.
    public void CloseButtons()
    {
        buttonsPanelSystem_MainScript.Close();
    }

    // ������� ������ ����� ����.
    public void NewGameStart()
    {
        mainMenuController.LoadScene("GameMenu");
    }

    // ������� �������� ����� ����� ����������. 
    public void GeneralTechnologyOpen()
    {
        mainMenuController.LoadScene("GeneralTechnology");
    }
}
