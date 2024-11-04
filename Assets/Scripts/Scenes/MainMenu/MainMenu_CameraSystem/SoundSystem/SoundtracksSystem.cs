using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtracksSystem : MonoBehaviour
{
    // ������ ��� ������������ ������.

    [SerializeField] private List<AudioClip> trackList = new List<AudioClip>();     // ������ ������.
    [SerializeField] private AudioSource audioSource;                               // ������ �� ����� ��� ������.

    private int currentTrack = 0;   // ��������� �� ��������� ����.

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
        if (!audioSource.isPlaying)
        {
            audioSource.clip = trackList[currentTrack];
            audioSource.Play();
            currentTrack = currentTrack == trackList.Count - 1 ? 0 : currentTrack + 1;
        }
    }
}
