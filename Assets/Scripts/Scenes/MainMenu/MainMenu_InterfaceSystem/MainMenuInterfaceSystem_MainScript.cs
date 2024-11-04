using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInterfaceSystem_MainScript : MonoBehaviour
{
    // Надсистемы:
    [SerializeField] MainMenuController mainMenuController;

    // Подсистемы:
    [SerializeField] private ButtonsPanelSystem_MainScript buttonsPanelSystem_MainScript;   // Система панели кнопок.
    [SerializeField] private SettingsSystem_MainScript settingsSystem_MainScript;           // Система окна настроек.
    [SerializeField] private SavesSystem_MainScript savesSystem_MainScript;                 // Система окна сохранений

    // Функция обновления громкости.
    public void UpdateSoundsVolume()
    {
        mainMenuController.SetVolumeOfSoundEffects();
        mainMenuController.SetVolumeOfSoundtracks();
    }

    // Функция установки громкости треков.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        mainMenuController.SetVolumeOfSoundtracks(soundtracks);
    }

    // Функция установки громкости треков.
    public void SetVolumeOfSoundtracks()
    {
        mainMenuController.SetVolumeOfSoundtracks();
    }

    // Функция установки громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        mainMenuController.SetVolumeOfSoundEffects(soundEffects);
    }

    // Функция установки громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects()
    {
        mainMenuController.SetVolumeOfSoundEffects();
    }

    // Функция загрузки сцены.
    public void LoadScene(string sceneName)
    {
        mainMenuController.LoadScene(sceneName);
    }

    // Функция открытия панели кнопок.
    public void OpenButtons()
    {
        buttonsPanelSystem_MainScript.Open();
    }

    // Функция закрытия панели кнопок.
    public void CloseButtons()
    {
        buttonsPanelSystem_MainScript.Close();
    }

    // Функция старта новой игры.
    public void NewGameStart()
    {
        mainMenuController.LoadScene("GameMenu");
    }

    // Функция загрузки сцены общих технологий. 
    public void GeneralTechnologyOpen()
    {
        mainMenuController.LoadScene("GeneralTechnology");
    }
}
