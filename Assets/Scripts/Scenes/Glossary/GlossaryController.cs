using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryController : MonoBehaviour
{
    // ���������� ���������

    // ����������
    [SerializeField] GlossaryCameraSystem glossaryCamera;
    [SerializeField] GlossaryInterfaceSystem glossaryInterface;
    [SerializeField] LoadingScreenSystem_MainScript loadingScreen;

    // ������� �������� �����
    public void LoadScene(string sceneName)
    {
        loadingScreen.LoadScene(sceneName);
    }

    // ������� ����� ��� ������
    public void MakeButtonSound()
    {
        glossaryCamera.MakeButtonSound();
    }
}
