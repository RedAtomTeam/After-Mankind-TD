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
    // ����������:
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // ������� ����������.

    // ����������:
    [SerializeField] Volume_SLIDER soundtracksVolumeSlider;     // ������� ��������� ������.
    [SerializeField] Volume_SLIDER soundEffectsVolumeSlider;    // ������� ��������� ��������

    // ���������� �������:
    [SerializeField] GameObject Settings_Obj;   // ������.
    private List<Resolution> resolutions;               // ��� ��������� ����������.
    public TMP_Dropdown resolutionDropdown;             // ������ �� ���������� ������ ���������� ������.
    public TMP_Dropdown qualityDropdown;                // ������ �� ���������� ������ ��������.
    public TMP_Dropdown languageDropdown;               // ������ �� ���������� ������ ������.
    public UnityEngine.UI.Toggle fullscreenToggle;                     // ������ �� ������������� �������������� ������.

    private void Start()
    {
        LoadSettings();
    }

    // ������� ��������� ��������� ������.
    public void ChangeVolumeOfSoundtracks(float soundtracks)
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundtracks(soundtracks / 100.0f);
    }

    // ������� ������������ �������� ��������� ������.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundtracks(soundtracks);
    }

    // ������� ������������ �������� ��������� ������.
    public void SetVolumeOfSoundtracks()
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundtracks();
    }

    // ������� ��������� ��������� �������� ��������.
    public void ChangeVolumeOfSoundEffects(float soundEffects)
    {
        
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundEffects(soundEffects / 100.0f);
    }

    // ������� ������������ �������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundEffects(soundEffects);
    }

    // ������� ������������ �������� ��������� �������� ��������.
    public void SetVolumeOfSoundEffects()
    {
        mainMenuInterfaceSystem_MainScript.SetVolumeOfSoundEffects();
    }

    // ������� �������� ����.
    public void Open()
    {
        Settings_Obj.SetActive(true);
    }

    // ������� �������� ����.
    public void Close()
    {
        Settings_Obj.SetActive(false);
    }

    // ������� ��������� �������������� ������.
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // ������� ��������� �������� �������.
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // ������� ��������� ���������� ������.
    public void SetResolution(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // ������� ��������� ���������� ������.
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    // ������� ��������� ��������� ��������.
    public void SetDefaultPreferences()
    {
        soundtracksVolumeSlider.SetVolume(50);
        soundEffectsVolumeSlider.SetVolume(50);
        SavePreferences();
    }

    // ������� ���������� ��������.
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

        qualityDropdown.options[0].text = PlayerPrefs.GetString("Language") == "�������" ? "�������" : "High";
        qualityDropdown.options[1].text = PlayerPrefs.GetString("Language") == "�������" ? "�������" : "Medium";
        qualityDropdown.options[2].text = PlayerPrefs.GetString("Language") == "�������" ? "������" : "Low";

        qualityDropdown.captionText.text = qualityDropdown.options[qualityDropdown.value].text;

    }

    public void SetLanguage()
    {
        string selectedLang = languageDropdown.options[languageDropdown.value].text;
        print("HUITAPOCHEMUTOVIPOLNOLAS");
        switch (selectedLang)
        {
            case "�������":
                PlayerPrefs.SetString("Language", "�������");
                break;
            case "English":
                PlayerPrefs.SetString("Language", "English");
                break;
        }
    }

    // ������� �������� ��������.
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

        // ���� � ������ ��� �������� �������� - ��������������� �������� �� ���������.
        // ����� ��������������� �������� �������� � ������ �������� � � ����. 
        if (!PlayerPrefs.HasKey("qualityPreference"))
            PlayerPrefs.SetInt("qualityPreference", 0);
        int qualityIndex = PlayerPrefs.GetInt("qualityPreference");
        qualityDropdown.value = qualityIndex;
        SetQuality(qualityIndex);
        //SetQuality(qualityIndex);

        // ���� � ������ ��� �������� ���������� - ��������������� �������� �� ���������.
        // ����� ��������������� �������� ���������� � ������ �������� � � ����.
        if (!PlayerPrefs.HasKey("resolutionPreference"))
            PlayerPrefs.SetInt("resolutionPreference", currentResolutionIndex);
        int resolutionIndex = PlayerPrefs.GetInt("resolutionPreference");
        resolutionDropdown.value = resolutionIndex;

        SetResolution(resolutions[resolutionDropdown.value]);

        //SetResolution(resolutionDropdown.value);

        // ���� � ������ ��� �������� �������������� ������ - ��������������� �������� �� ���������.
        // ����� ��������������� �������� �������������� ������ � ������ �������� � � ����.
        if (!PlayerPrefs.HasKey("fullscreenPreference"))
            PlayerPrefs.SetInt("fullscreenPreference", 1);
        bool fullscreenIndex = System.Convert.ToBoolean(PlayerPrefs.GetInt("fullscreenPreference"));
        Screen.fullScreen = fullscreenIndex;
        fullscreenToggle.isOn = fullscreenIndex;

        // ���� � ������ ��� �������� ��������� ����� ��� ������ - ��������������� �������� �� ���������.
        // ����� ��������������� �������� ��������� ����� ��� ������ � ������ �������� � � ����.
        if (!PlayerPrefs.HasKey("volumePreference"))
        {
            PlayerPrefs.SetInt("volumePreference", 50);
        }
        int volumeIndex = PlayerPrefs.GetInt("volumePreference");

        SetVolumeOfSoundtracks(volumeIndex / 100.0f);
        soundtracksVolumeSlider.SetVolume(volumeIndex);

        // ���� � ������ ��� �������� ��������� ����� ��� �������� - ��������������� �������� �� ���������.
        // ����� ��������������� �������� ��������� ����� ��� �������� � ������ �������� � � ����.
        if (!PlayerPrefs.HasKey("effectsVolumePreference"))
            PlayerPrefs.SetInt("effectsVolumePreference", 50);
        int effectsVolumeIndex = PlayerPrefs.GetInt("effectsVolumePreference");

        SetVolumeOfSoundEffects(effectsVolumeIndex / 100.0f);
        soundEffectsVolumeSlider.SetVolume(effectsVolumeIndex);


        // ���� � ������ ��� �������� ����� - ��������������� �������� �� ���������.
        // ����� ��������������� ���� � ������ �������� � � ����.
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetString("Language", "�������");
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
