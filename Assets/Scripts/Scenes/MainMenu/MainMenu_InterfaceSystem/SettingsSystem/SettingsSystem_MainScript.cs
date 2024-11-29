using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SettingsSystem_MainScript : MonoBehaviour
{
    // Надсистемы:
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // Система интерфейса.

    // Подсистемы:
    [SerializeField] Volume_SLIDER soundtracksVolumeSlider;     // Слайдер громкости треков.
    [SerializeField] Volume_SLIDER soundEffectsVolumeSlider;    // Слайдер громкости эффектов

    // Переменные системы:
    [SerializeField] GameObject Settings_Obj;   // Объект.
    private List<Resolution> resolutions;               // Все доступные разрешения.
    public TMP_Dropdown resolutionDropdown;             // Ссылка на выпадающий список разрешения экрана.
    public TMP_Dropdown qualityDropdown;                // Ссылка на выпадающий список качества.
    public TMP_Dropdown languageDropdown;               // Ссылка на выпадающий список языков.
    public UnityEngine.UI.Toggle fullscreenToggle;                     // Ссылка на переключатель полноэкранного режима.

    private void Start()
    {
        LoadSettings();
    }

    // Функция изменения громкости треков.
    public void ChangeVolumeOfSoundtracks(float soundtracks)
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundtracks(soundtracks / 100.0f);
    }

    // Функция присваивания значения громкости треков.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundtracks(soundtracks);
    }

    // Функция присваивания значения громкости треков.
    public void SetVolumeOfSoundtracks()
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundtracks();
    }

    // Функция изменения громкости звуковых эффектов.
    public void ChangeVolumeOfSoundEffects(float soundEffects)
    {
        
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundEffects(soundEffects / 100.0f);
    }

    // Функция присваивания значения громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundEffects(soundEffects);
    }

    // Функция присваивания значения громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects()
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundEffects();
    }

    // Функция открытия окна.
    public void Open()
    {
        Settings_Obj.SetActive(true);
    }

    // Функция открытия окна.
    public void Close()
    {
        Settings_Obj.SetActive(false);
    }

    // Функция установки полноэкранного режима.
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Функция установки качества графики.
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Функция установки разрешения экрана.
    public void SetResolution(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Функция установки разрешения экрана.
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    // Функция установки дефолтных настроек.
    public void SetDefaultPreferences()
    {
        soundtracksVolumeSlider.SetVolume(50);
        soundEffectsVolumeSlider.SetVolume(50);
        SavePreferences();
    }

    // Функция сохранения настроек.
    public void SavePreferences()
    {
        PlayerPrefs.SetInt("qualityPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("resolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("fullscreenPreference", Convert.ToInt32(fullscreenToggle.isOn));
        PlayerPrefs.SetInt("volumePreference", soundtracksVolumeSlider.GetVolume());
        PlayerPrefs.SetInt("effectsVolumePreference", soundEffectsVolumeSlider.GetVolume());
        PlayerPrefs.SetString("Language", languageDropdown.options[languageDropdown.value].text);
    }

    private void Update()
    {
        UpdateQualityLanguage();
    }

    public void UpdateQualityLanguage()
    {

        qualityDropdown.options[0].text = PlayerPrefs.GetString("Language") == "Русский" ? "Высокое" : "High";
        qualityDropdown.options[1].text = PlayerPrefs.GetString("Language") == "Русский" ? "Среднее" : "Medium";
        qualityDropdown.options[2].text = PlayerPrefs.GetString("Language") == "Русский" ? "Низкое" : "Low";

        qualityDropdown.captionText.text = qualityDropdown.options[qualityDropdown.value].text;

    }

    public void SetLanguage()
    {
        string selectedLang = languageDropdown.options[languageDropdown.value].text;
        print("HUITAPOCHEMUTOVIPOLNOLAS");
        switch (selectedLang)
        {
            case "Русский":
                PlayerPrefs.SetString("Language", "Русский");
                break;
            case "English":
                PlayerPrefs.SetString("Language", "English");
                break;
        }
    }

    // Функция загрузки настроек.
    public void LoadSettings()
    {
        resolutions = new List<Resolution>();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        foreach (Resolution res in Screen.resolutions)
        {
            if (res.width >= 1600 && res.height >= 1000)
            {
                resolutions.Add(res);
            }
        }

        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

        // Если в памяти нет настроек качества - устанавливается значение по умолчанию.
        // После устанавливается значение качества в панеле настроек и в игре. 
        if (!PlayerPrefs.HasKey("qualityPreference"))
            PlayerPrefs.SetInt("qualityPreference", 0);
        int qualityIndex = PlayerPrefs.GetInt("qualityPreference");
        qualityDropdown.value = qualityIndex;
        SetQuality(qualityIndex);
        //SetQuality(qualityIndex);

        // Если в памяти нет настроек разрешения - устанавливается значение по умолчанию.
        // После устанавливается значение разрешения в панеле настроек и в игре.
        if (!PlayerPrefs.HasKey("resolutionPreference"))
            PlayerPrefs.SetInt("resolutionPreference", currentResolutionIndex);
        int resolutionIndex = PlayerPrefs.GetInt("resolutionPreference");
        resolutionDropdown.value = resolutionIndex;

        SetResolution(resolutions[resolutionDropdown.value]);

        //SetResolution(resolutionDropdown.value);

        // Если в памяти нет настроек полноэкранного режима - устанавливается значение по умолчанию.
        // После устанавливается значение полноэкранного режима в панеле настроек и в игре.
        if (!PlayerPrefs.HasKey("fullscreenPreference"))
            PlayerPrefs.SetInt("fullscreenPreference", 1);
        bool fullscreenIndex = System.Convert.ToBoolean(PlayerPrefs.GetInt("fullscreenPreference"));
        Screen.fullScreen = fullscreenIndex;
        fullscreenToggle.isOn = fullscreenIndex;

        // Если в памяти нет настроек громкости звука для музыки - устанавливается значение по умолчанию.
        // После устанавливается значение громкости звука для музыки в панеле настроек и в игре.
        if (!PlayerPrefs.HasKey("volumePreference"))
        {
            PlayerPrefs.SetInt("volumePreference", 50);
        }
        int volumeIndex = PlayerPrefs.GetInt("volumePreference");

        SetVolumeOfSoundtracks(volumeIndex / 100.0f);
        soundtracksVolumeSlider.SetVolume(volumeIndex);

        // Если в памяти нет настроек громкости звука для эффектов - устанавливается значение по умолчанию.
        // После устанавливается значение громкости звука для эффектов в панеле настроек и в игре.
        if (!PlayerPrefs.HasKey("effectsVolumePreference"))
            PlayerPrefs.SetInt("effectsVolumePreference", 50);
        int effectsVolumeIndex = PlayerPrefs.GetInt("effectsVolumePreference");

        SetVolumeOfSoundEffects(effectsVolumeIndex / 100.0f);
        soundEffectsVolumeSlider.SetVolume(effectsVolumeIndex);


        // Если в памяти нет настроек языка - устанавливается значение по умолчанию.
        // После устанавливается язык в панеле настроек и в игре.
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetString("Language", "Русский");
        }
        for (int i = 0; i < languageDropdown.options.Count; i++)
        {
            if (languageDropdown.options[i].text == PlayerPrefs.GetString("Language"))
            {
                languageDropdown.value = i;
                break;
            }
        }

    }
}
