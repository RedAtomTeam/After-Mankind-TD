using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraSystem_MainScript : MonoBehaviour
{
    // Надсистемы.
    //[SerializeField] MainMenuController mainMenuController;

    // Системы одного уровня.
    //[SerializeField] private MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScript;     // Система интерфейса.

    // Подсистемы.
    [SerializeField] private SoundSystem_MainScript soundSystem_MainScript;     // Звуковая система

    // Функция обновления громкости.
    // При отсутствии значения в качестве громкости устанавливается значение, сохранённое в PlayerPrefs.
    public void UpdateSoundsVolume()
    {
        soundSystem_MainScript.SetVolumeOfSoundEffects();
        soundSystem_MainScript.SetVolumeOfSoundtracks();
    }

    // Функция установки громкости саундтреков.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        soundSystem_MainScript.SetVolumeOfSoundtracks(soundtracks);
    }

    // Перегрузка функция установки громкости саундтреков. 
    // При отсутствии значения в качестве громкости устанавливается значение, сохранённое в PlayerPrefs.
    public void SetVolumeOfSoundtracks()
    {
        soundSystem_MainScript.SetVolumeOfSoundtracks();
    }

    // Функция установки громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        soundSystem_MainScript.SetVolumeOfSoundEffects(soundEffects);
    }

    // Перегрузка функция установки громкости звуковых эффектов. 
    // При отсутствии значения в качестве громкости устанавливается значение, сохранённое в PlayerPrefs.
    public void SetVolumeOfSoundEffects()
    {
        soundSystem_MainScript.SetVolumeOfSoundEffects();
    }
}
