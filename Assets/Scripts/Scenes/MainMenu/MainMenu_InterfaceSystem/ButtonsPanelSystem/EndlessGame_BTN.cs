using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ������ ��� �������� ���� ���������� ����.
public class EndlessGame_BTN : MonoBehaviour
{
    // ������� ��� �������� ���� ���������� ����.
    public void LoadEndlessGame()
    {
        SceneManager.LoadScene("EndlessGameMenu");
    }
}
