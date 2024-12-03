using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class LoadingScreenSystem_VideoController : MonoBehaviour
{
    [SerializeField] List<VideoClip> videoClips = new List<VideoClip>();    // Список видеоклипов.
    [SerializeField] VideoPlayer videoPlayer;                               // Видеоплеер.
    int currentVideo;   // Указатель на нынешнее видео.

    // Функция запуска работы по выводу видео.
    public void StartVideos()
    {
        currentVideo = Random.Range(0, videoClips.Count-1);
    }

    // Постоянно контролируем состояние плеера. Если ничего не проигрывается - ставим новый ролик. 
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
