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

    // ������� ��������� �������� Passed
    public void SetPassed()
    {
        lineObject.color = passedColor;
    }

    // ������� ��������� �������� Opened
    public void SetOpened()
    {
        lineObject.color = openedColor;
    }

    // ������� ��������� �������� Closed
    public void SetClosed()
    {
        lineObject.color = closedColor;
    }
}
