using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Скрипт для загрузки меню бесконечно игры.
public class EndlessGame_BTN : MonoBehaviour
{
    // Функция для загрузки меню бесконечно игры.
    public void LoadEndlessGame()
    {
        SceneManager.LoadScene("EndlessGameMenu");
    }
}
