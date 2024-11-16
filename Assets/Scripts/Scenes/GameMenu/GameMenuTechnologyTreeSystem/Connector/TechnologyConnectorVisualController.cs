using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechnologyConnectorVisualController : MonoBehaviour
{
    [SerializeField] RawImage lineObject;
    [SerializeField] Color passedColor;
    [SerializeField] Color openedColor;
    [SerializeField] Color closedColor;

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
