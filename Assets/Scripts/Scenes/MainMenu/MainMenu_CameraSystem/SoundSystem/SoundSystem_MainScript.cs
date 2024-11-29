using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem_MainScript : MonoBehaviour
{
    // Класс управления звуками.

    // Подсистемы.
    [SerializeField] SoundtracksSystem soundtracksSystem;       // Скрипт управления громкостью саундтреков.
    [SerializeField] SoundEffectsSystem soundEffectsSystem;     // Скрипт управления громкостью звуковых эффектов.


    // Функция установки громкости саундтреков.
    public void SetVolumeOfSoundtracks(float soundtracks)
    {
        soundtracksSystem.SetVolume(soundtracks);
    }

    // Функция установки громкости саундтреков.
    public void SetVolumeOfSoundtracks()
    {
        soundtracksSystem.SetVolume();
    }

    // Функция установки громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects(float soundEffects)
    {
        soundEffectsSystem.SetVolume(soundEffects);
    }

    // Функция установки громкости звуковых эффектов.
    public void SetVolumeOfSoundEffects()
    {
        soundEffectsSystem.SetVolume();
    }

    public void MakeButtonSound()
    {
        soundEffectsSystem.MakeButtonSound();
    }
}
