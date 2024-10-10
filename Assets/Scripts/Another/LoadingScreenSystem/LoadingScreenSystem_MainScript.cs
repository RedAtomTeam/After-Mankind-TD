using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScreenSystem_MainScript : MonoBehaviour
{
    // Класс управления загрузкой сцен.

    [SerializeField] private GameObject loadingScreenSystem_Obj;                            // Канвас с видео.
    [SerializeField] private LoadingScreenSystem_TextController loadingScreenTextSystem;    // Ссылка на класс контроллера текста.
    [SerializeField] private LoadingScreenSystem_VideoController loadingScreenVideoSystem;  // Ссылка на класс контроллера видео.
    [SerializeField] private float timeText;                                                // Время на совет.


    // При запуске инициализируем показатели времени на ролики и текст.
    private void Start()
    {
        loadingScreenTextSystem.time = timeText;
    }

    // Получаем название сцены, делаем активным канвас загрузки, выводим
    // текст и запукаем корутину с соответствующим названием.
    public void LoadScene(string sceneName)
    {
        loadingScreenSystem_Obj.SetActive(true);

        loadingScreenTextSystem.StartTexts();
        loadingScreenVideoSystem.StartVideos();

        print(1);

        StartCoroutine(LoadAsync(sceneName));
    }

    // Асинхронно загружаем сцену с переданным названием и открываем её по готовности.
    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneName);
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone) 
        { 
            if (loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
