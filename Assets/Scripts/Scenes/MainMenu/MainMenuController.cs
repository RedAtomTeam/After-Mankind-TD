using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] LoadingScreenSystem_MainScript loadingScreenSystem;
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterface;
    [SerializeField] private MainMenuCameraSystem_MainScript mainMenuCameraSystem;

    // ������� ���������� ���������.
    public void UpdateSoundsVolume()
    {
        mainMenuCameraSystem.SetVolumeOfSoundEffects();
        mainMenuCameraSystem.SetVolumeOfSoundtracks();
    }

    // ������� ��������� ��������� ������.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        mainMenuCameraSystem.SetVolumeOfSoundtracks(soundtracks);
    }

    // ������� ��������� ��������� ������.
    public void SetVolumeOfSoundtracks()
    {
        mainMenuCameraSystem.SetVolumeOfSoundtracks();
    }

    // ������� ��������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        mainMenuCameraSystem.SetVolumeOfSoundEffects(soundEffects);
    }

    // ������� ��������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects()
    {
        mainMenuCameraSystem.SetVolumeOfSoundEffects();
    }

    // ������� �������� �����.
    public void LoadScene(string sceneName)
    {
        loadingScreenSystem.LoadScene(sceneName);
    }
}
