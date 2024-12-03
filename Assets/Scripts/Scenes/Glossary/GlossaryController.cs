using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryController : MonoBehaviour
{
    // Контроллер глоссария

    // Подсистемы
    [SerializeField] GlossaryCameraSystem glossaryCamera;
    [SerializeField] GlossaryInterfaceSystem glossaryInterface;
    [SerializeField] LoadingScreenSystem_MainScript loadingScreen;

    // Функция загрузки сцены
    public void LoadScene(string sceneName)
    {
        loadingScreen.LoadScene(sceneName);
    }

    // Функция звука для кнопки
    public void MakeButtonSound()
    {
        glossaryCamera.MakeButtonSound();
    }
}
