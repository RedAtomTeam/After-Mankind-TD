using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsSystem : MonoBehaviour
{
    // ����� ��� ��������� ����������� ��������
    // ��������� �������� ���� ��������� ���������.

    void Start()
    {
        SetVolume();
    }

    // ������� ��������� ���������.
    public void SetVolume(float volume)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioSource>().volume = volume;
        }
    }

    // ������� ��������� ���������.
    public void SetVolume()
    {
        float volume = PlayerPrefs.GetInt("effectsVolumePreference") / 100f;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioSource>().volume = volume;
        }
    }
}
