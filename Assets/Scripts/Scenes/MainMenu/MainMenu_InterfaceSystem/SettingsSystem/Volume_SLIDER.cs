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
    // Скрипт для слайдера, отвечающего за устанвоку громкости звука для треков.


    // Надсистем:
    [SerializeField] private SettingsSystem_MainScript settingsSystem_MainScript;   // Система управления настройками.


    // Системы одного уровня:



    // Подсистемы:



    // Внутренние переменные.
    [SerializeField] Slider volumeSliderObj; // Слайдер для регулировки звука.
    [SerializeField] TextMeshProUGUI volumeIndexObj; // Текст, отображающий громкость звука.

   

    // Функция смены громкость звука для саундтреков.
    public void ChangeVolumeIndex()
    {
        // Получаем значение со слайдера, отвечающего за громкость.
        string volumeIndexNow = Convert.ToString(volumeSliderObj.value);
        // Устанавливаем значение слайдера.
        volumeIndexObj.SetText($"{volumeIndexNow}/100");
    }

    // Функция установки громкости.
    public void SetVolume(int volume)
    {
        volumeSliderObj.value = volume;
        // Устанавливаем значение слайдера.
        volumeIndexObj.SetText($"{volume}/100");
    }

    // Функция установки громкости.
    public int GetVolume()
    {
        return (int)volumeSliderObj.value;
    }
}
