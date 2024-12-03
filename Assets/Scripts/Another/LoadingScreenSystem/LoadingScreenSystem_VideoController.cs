using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class LoadingScreenSystem_VideoController : MonoBehaviour
{
    [SerializeField] List<VideoClip> videoClips = new List<VideoClip>();    // ������ �����������.
    [SerializeField] VideoPlayer videoPlayer;                               // ����������.
    int currentVideo;   // ��������� �� �������� �����.

    // ������� ������� ������ �� ������ �����.
    public void StartVideos()
    {
        currentVideo = Random.Range(0, videoClips.Count-1);
    }

    // ��������� ������������ ��������� ������. ���� ������ �� ������������� - ������ ����� �����. 
    public void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.clip = videoClips[currentVideo];
            videoPlayer.Play();
            currentVideo = (currentVideo + 1) == videoClips.Count ? 0 : (currentVideo + 1);
        }
    }
}
