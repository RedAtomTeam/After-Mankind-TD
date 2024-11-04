using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;


public class Volume_SLIDER : MonoBehaviour
{
    // ������ ��� ��������, ����������� �� ��������� ��������� ����� ��� ������.


    // ���������:
    [SerializeField] private SettingsSystem_MainScript settingsSystem_MainScript;   // ������� ���������� �����������.


    // ������� ������ ������:



    // ����������:



    // ���������� ����������.
    [SerializeField] Slider volumeSliderObj; // ������� ��� ����������� �����.
    [SerializeField] TextMeshProUGUI volumeIndexObj; // �����, ������������ ��������� �����.

   

    // ������� ����� ��������� ����� ��� �����������.
    public void ChangeVolumeIndex()
    {
        // �������� �������� �� ��������, ����������� �� ���������.
        string volumeIndexNow = Convert.ToString(volumeSliderObj.value);
        // ������������� �������� ��������.
        volumeIndexObj.SetText($"{volumeIndexNow}/100");
    }

    // ������� ��������� ���������.
    public void SetVolume(int volume)
    {
        volumeSliderObj.value = volume;
        // ������������� �������� ��������.
        volumeIndexObj.SetText($"{volume}/100");
    }

    // ������� ��������� ���������.
    public int GetVolume()
    {
        return (int)volumeSliderObj.value;
    }
}
