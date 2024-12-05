using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtracksSystem : MonoBehaviour
{
    // ������ ��� ������������ ������.

    [SerializeField] List<AudioClip> trackList = new List<AudioClip>();     // ������ ������.
    [SerializeField] AudioSource audioSource;                               // ������ �� ����� ��� ������.

    int currentTrack = 0;   // ��������� �� ��������� ����.

    // ��� ������ ������������� ���������� ���������.
    private void Start()
    {
        SetVolume();
    }

    // ������� ��������� ���������.
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // ������� ��������� ���������.
    public void SetVolume()
    {
        audioSource.volume = PlayerPrefs.GetInt("volumePreference") / 100f;
    }

    // ����������� ������������ ������ � ������ �� ���������.
    private void Update()
    {
        print(!audioSource.isPlaying);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = trackList[currentTrack];
            audioSource.Play();
            currentTrack = currentTrack == trackList.Count - 1 ? 0 : currentTrack + 1;
        }
    }
}
