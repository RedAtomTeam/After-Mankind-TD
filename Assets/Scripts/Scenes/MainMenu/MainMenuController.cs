using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] LoadingScreenSystem_MainScript loadingScreenSystem;
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterface;
    [SerializeField] private MainMenuCameraSystem_MainScript mainMenuCameraSystem;

    // Функция обновления громкости.
    public void UpdateSoundsVolume()
    {
        mainMenuCameraSystem.SetVolumeOfSoundEffects();
        mainMenuCameraSystem.SetVolumeOfSoundtracks();
    }

    // Функция установки громкости треков.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        mainMenuCameraSystem.SetVolumeOfSoundtracks(soundtracks);
    }

    // Функция установки громкости треков.
    public void SetVolumeOfSoundtracks()
    {
        mainMenuCameraSystem.SetVolumeOfSoundtracks();
    }

    // Функция установки громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        mainMenuCameraSystem.SetVolumeOfSoundEffects(soundEffects);
    }

    // Функция установки громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects()
    {
        mainMenuCameraSystem.SetVolumeOfSoundEffects();
    }

    // Функция загрузки сцены.
    public void LoadScene(string sceneName)
    {
        loadingScreenSystem.LoadScene(sceneName);
    }
}
