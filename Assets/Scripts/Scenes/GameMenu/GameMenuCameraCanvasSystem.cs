using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuCameraCanvasSystem : MonoBehaviour
{
    [SerializeField] private GameMenuController gameMenuController;

    [SerializeField] private GameMenuInterfaceSystem gameMenuInterfaceSystem;

    public void cameraMovementOn()
    {
        gameMenuController.cameraMovementOn();
    }

    public void cameraMovementOff()
    {
        gameMenuController.cameraMovementOff();
    }

    public void OpenLevelInfo(Level level)
    {
        gameMenuInterfaceSystem.OpenLevelInfo(level);
    }

    public void OpenTechInfo(Technology tech)
    {
        gameMenuInterfaceSystem.OpenTechInfo(tech);
    }

    public void OpenTechTreeTab() 
    {
        gameMenuController.OpenTechTreeTab();
    }

    public void OpenMapTab()
    {
        gameMenuController.OpenMapTab();
    }
}
