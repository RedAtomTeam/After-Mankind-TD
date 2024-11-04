using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraSystem_MainScript : MonoBehaviour
{
    // ����������.
    //[SerializeField] MainMenuController mainMenuController;

    // ������� ������ ������.
    //[SerializeField] private MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // ������� ����������.

    // ����������.
    [SerializeField] private SoundSystem_MainScript soundSystem_MainScript;     // �������� �������

    // ������� ���������� ���������.
    // ��� ���������� �������� � �������� ��������� ��������������� ��������, ���������� � PlayerPrefs.
    public void UpdateSoundsVolume()
    {
        soundSystem_MainScript.SetVolumeOfSoundEffects();
        soundSystem_MainScript.SetVolumeOfSoundtracks();
    }

    // ������� ��������� ��������� �����������.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        soundSystem_MainScript.SetVolumeOfSoundtracks(soundtracks);
    }

    // ���������� ������� ��������� ��������� �����������. 
    // ��� ���������� �������� � �������� ��������� ��������������� ��������, ���������� � PlayerPrefs.
    public void SetVolumeOfSoundtracks()
    {
        soundSystem_MainScript.SetVolumeOfSoundtracks();
    }

    // ������� ��������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        soundSystem_MainScript.SetVolumeOfSoundEffects(soundEffects);
    }

    // ���������� ������� ��������� ��������� �������� ��������. 
    // ��� ���������� �������� � �������� ��������� ��������������� ��������, ���������� � PlayerPrefs.
    public void SetVolumeOfSoundEffects()
    {
        soundSystem_MainScript.SetVolumeOfSoundEffects();
    }
}
