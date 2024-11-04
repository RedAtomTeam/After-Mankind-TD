using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security.Cryptography;
using System;
using Unity.VisualScripting;

public class LoadingSettings : MonoBehaviour
{
    // Класс для загрузки настроек


    public TMP_Dropdown resolutionDropdown;     // Ссылка на выпадающий список разрешений.
    public TMP_Dropdown qualityDropdown;        // Ссылка на выпадающий спсиок качества.
    public TMP_Dropdown languageDropdown;       // Ссылка на выпадающий список языков.
    public Slider volumeSlider;                 // Ссылка на слайдер громкости.
    public List<Resolution> resolutions;        // Список разрешений.
    [SerializeField] Toggle fullscreenToggle;   // Ссылка на переключатель полноэкранного режима

    [SerializeField] private Slider effectsVolumeSlider;        // Ссылка на слайдер громкости эффектов.

    [SerializeField] private SettingsSystem_MainScript settingsSystem_MainScript;

    // Сначала устанавливаепм список разрешений исходя из доступных на устройстве.
    void Start()
    {
        /*resolutions = new List<Resolution>();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        foreach (Resolution res in Screen.resolutions)
        {
            if (res.width >= 1200 && res.height >= 800)
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
        LoadSettings(currentResolutionIndex);*/

        LoadSettings();
    }

    // Установка настроек в панеле настроек и в игре.
    public void LoadSettings()
    {
        resolutions = new List<Resolution>();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        foreach (Resolution res in Screen.resolutions)
        {
            if (res.width >= 1200 && res.height >= 800)
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
            PlayerPrefs.SetInt("qualityPreference", 3);
        int qualityIndex = PlayerPrefs.GetInt("qualityPreference");
        qualityDropdown.value = qualityIndex;
        settingsSystem_MainScript.SetQuality(qualityIndex);
        //SetQuality(qualityIndex);

        // Если в памяти нет настроек разрешения - устанавливается значение по умолчанию.
        // После устанавливается значение разрешения в панеле настроек и в игре.
        if (!PlayerPrefs.HasKey("resolutionPreference"))
            PlayerPrefs.SetInt("resolutionPreference", currentResolutionIndex);
        int resolutionIndex = PlayerPrefs.GetInt("resolutionPreference");
        resolutionDropdown.value = resolutionIndex;

        settingsSystem_MainScript.SetResolution(resolutions[resolutionDropdown.value]);

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
        print(PlayerPrefs.GetInt("volumePreference"));
        if (!PlayerPrefs.HasKey("volumePreference"))
        {
            print("None");
            PlayerPrefs.SetInt("volumePreference", 50);
        }
        print(PlayerPrefs.GetInt("volumePreference"));
        int volumeIndex = PlayerPrefs.GetInt("volumePreference");

       /* print(volumeSlider == null);
        print(volumeIndex == null);
        print(volumeIndex);
        print(volumeSlider.value == null);
        print(volumeSlider.value);*/
        
        /*volumeSlider.value 
            = 
            volumeIndex;*/

        settingsSystem_MainScript.SetVolumeOfSoundtracks(volumeIndex / 100.0f);

        // Если в памяти нет настроек громкости звука для эффектов - устанавливается значение по умолчанию.
        // После устанавливается значение громкости звука для эффектов в панеле настроек и в игре.
        if (!PlayerPrefs.HasKey("effectsVolumePreference"))
            PlayerPrefs.SetInt("effectsVolumePreference", 50);
        int effectsVolumeIndex = PlayerPrefs.GetInt("effectsVolumePreference");
        effectsVolumeSlider.value = effectsVolumeIndex;

        settingsSystem_MainScript.SetVolumeOfSoundEffects(effectsVolumeIndex / 100.0f);


        // Если в памяти нет настроек языка - устанавливается значение по умолчанию.
        // После устанавливается язык в панеле настроек и в игре.
        if (PlayerPrefs.HasKey("languagePreference"))
            PlayerPrefs.SetInt("languagePreference", 0);
        int languageIndex = PlayerPrefs.GetInt("languagePreference");
        languageDropdown.value = languageIndex;
        
    }

    // Функция для установки разрешения и размера элементов меню.
    /*public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        //backgroundVideo.GetComponent<RectTransform>().sizeDelta = new Vector2(resolution.height*1.78f, resolution.height);

        // Разделение на >= 1000 и < 1000 производится для рассчёта размера панели меню - есть только два случая.
        *//*if (resolution.height < 1000)
        {
            buttonsPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonsPanel.GetComponent<RectTransform>().rect.width, 600);
            int i = 1;
            foreach(Transform child in buttonsPanel.transform)
            {
                child.GetComponent<RectTransform>().sizeDelta = new Vector2(child.GetComponent<RectTransform>().rect.width, 80);
                int newY = 600 - ((5 + 80) * i) - 260;
                child.localPosition = new Vector3(0, newY, 0);
                i++;
            }

            lines.transform.GetChild(0).transform.localPosition = new Vector3(0, -70, 0);
            lines.transform.GetChild(1).transform.localPosition = new Vector3(0, 70, 0);

            int newX = (resolution.width/2) - 220;
            buttonsPanel.transform.localPosition = new Vector3(newX, -10, 0);
            lines.transform.localPosition = new Vector3(newX, 70, 0);
            gameName.GetComponent<TextMeshProUGUI>().fontSize = 36;
        }

        else
        {
            buttonsPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonsPanel.GetComponent<RectTransform>().rect.width, 740);
            int i = 1;
            foreach (Transform child in buttonsPanel.transform)
            {
                child.GetComponent<RectTransform>().sizeDelta = new Vector2(child.GetComponent<RectTransform>().rect.width, 100);
                int newY = 740 - ((5 + 100) * i) - 320;
                child.localPosition = new Vector3(0, newY, 0);
                i++;
            }

            lines.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
            lines.transform.GetChild(1).transform.localPosition = new Vector3(0, 0, 0);

            int newX = (resolution.width / 2) - 220;
            buttonsPanel.transform.localPosition = new Vector3(newX, -80, 0);
            lines.transform.localPosition = new Vector3(newX, 0, 0);
            gameName.GetComponent<TextMeshProUGUI>().fontSize = 54;
        }*//*
    }*/

    /*public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }*/
}