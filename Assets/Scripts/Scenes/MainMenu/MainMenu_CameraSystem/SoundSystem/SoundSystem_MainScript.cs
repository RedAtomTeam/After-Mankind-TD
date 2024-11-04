using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem_MainScript : MonoBehaviour
{
    // ����� ���������� �������.

    // ����������.
    [SerializeField] private SoundtracksSystem soundtracksSystem;       // ������ ���������� ���������� �����������.
    [SerializeField] private SoundEffectsSystem soundEffectsSystem;     // ������ ���������� ���������� �������� ��������.


    // ������� ��������� ��������� �����������.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        soundtracksSystem.SetVolume(soundtracks);
    }

    // ������� ��������� ��������� �����������.
    public void SetVolumeOfSoundtracks()
    {
        soundtracksSystem.SetVolume();
    }

    // ������� ��������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        soundEffectsSystem.SetVolume(soundEffects);
    }

    // ������� ��������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects()
    {
        soundEffectsSystem.SetVolume();
    }
}
