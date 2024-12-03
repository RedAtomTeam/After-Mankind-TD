using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryCameraSystem : MonoBehaviour
{
    // Подсистемы
    [SerializeField] SoundSystem_MainScript soundSystem;

    // Функция звука для кнопки
    public void MakeButtonSound()
    {
        soundSystem.MakeButtonSound();
    }
}
