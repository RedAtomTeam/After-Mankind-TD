using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryCameraSystem : MonoBehaviour
{
    // ����������
    [SerializeField] SoundSystem_MainScript soundSystem;

    // ������� ����� ��� ������
    public void MakeButtonSound()
    {
        soundSystem.MakeButtonSound();
    }
}
