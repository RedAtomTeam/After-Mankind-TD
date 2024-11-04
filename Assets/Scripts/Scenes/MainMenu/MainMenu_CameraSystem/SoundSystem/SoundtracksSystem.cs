using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtracksSystem : MonoBehaviour
{
    // Скрипт для проигрывания треков.

    [SerializeField] private List<AudioClip> trackList = new List<AudioClip>();     // Список треков.
    [SerializeField] private AudioSource audioSource;                               // Ссылка на вывод для треков.

    private int currentTrack = 0;   // Указатель на настоящий трек.

    // При старте устанавливаем актуальную громкость.
    private void Start()
    {
        SetVolume();
    }

    // Функция установки громкости.
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Функция установки громкости.
    public void SetVolume()
    {
        audioSource.volume = PlayerPrefs.GetInt("volumePreference") / 100f;
    }

    // Отслеживаем проигрывание треков и меняем на следующие.
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = trackList[currentTrack];
            audioSource.Play();
            currentTrack = currentTrack == trackList.Count - 1 ? 0 : currentTrack + 1;
        }
    }
}
