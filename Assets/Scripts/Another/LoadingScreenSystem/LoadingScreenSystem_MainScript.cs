using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScreenSystem_MainScript : MonoBehaviour
{
    // ����� ���������� ��������� ����.

    [SerializeField] private GameObject loadingScreenSystem_Obj;                            // ������ � �����.
    [SerializeField] private LoadingScreenSystem_TextController loadingScreenTextSystem;    // ������ �� ����� ����������� ������.
    [SerializeField] private LoadingScreenSystem_VideoController loadingScreenVideoSystem;  // ������ �� ����� ����������� �����.
    [SerializeField] private float timeText;                                                // ����� �� �����.


    // ��� ������� �������������� ���������� ������� �� ������ � �����.
    private void Start()
    {
        loadingScreenTextSystem.time = timeText;
    }

    // �������� �������� �����, ������ �������� ������ ��������, �������
    // ����� � �������� �������� � ��������������� ���������.
    public void LoadScene(string sceneName)
    {
        loadingScreenSystem_Obj.SetActive(true);

        loadingScreenTextSystem.StartTexts();
        loadingScreenVideoSystem.StartVideos();

        print(1);

        StartCoroutine(LoadAsync(sceneName));
    }

    // ���������� ��������� ����� � ���������� ��������� � ��������� � �� ����������.
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
