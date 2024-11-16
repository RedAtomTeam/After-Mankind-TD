using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLinkVisualController : MonoBehaviour
{
    [SerializeField] Image lineObject;
    [SerializeField] Color passedColor;
    [SerializeField] Color openedColor;
    [SerializeField] Color closedColor;

    // Функция установки состояни Passed
    public void SetPassed()
    {
        lineObject.color = passedColor;
    }

    // Функция установки состояни Opened
    public void SetOpened()
    {
        lineObject.color = openedColor;
    }

    // Функция установки состояни Closed
    public void SetClosed()
    {
        lineObject.color = closedColor;
    }
}
