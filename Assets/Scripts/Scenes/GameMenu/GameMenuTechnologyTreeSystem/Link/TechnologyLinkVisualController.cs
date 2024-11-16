using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechnologyLinkVisualController : MonoBehaviour
{
    [SerializeField] private Image lineObject;
    [SerializeField] private Color passedColor;
    [SerializeField] private Color openedColor;
    [SerializeField] private Color closedColor;

    public void SetPassed()
    {
        lineObject.color = passedColor;
    }

    public void SetOpened()
    {
        lineObject.color = openedColor;
    }

    public void SetClosed()
    {
        lineObject.color = closedColor;
    }
}
