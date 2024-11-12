using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuInterfaceSystem : MonoBehaviour
{
    [SerializeField] private GameMenuCameraCanvasSystem gameMenuCameraCanvasSystem;

    [SerializeField] private GameMenuLevelInfoSystem gameMenuLevelInfoSystem;
    [SerializeField] private GameMenuTechnologyInfoSystem gameMenuTechnologyInfoSystem;


    public void cameraMovementOn()
    {
        gameMenuCameraCanvasSystem.cameraMovementOn();
    }

    public void cameraMovementOff()
    {
        gameMenuCameraCanvasSystem.cameraMovementOff();
    }

    public void StartLevel(int ID)
    {

    }

    public void OpenTechTreeTab()
    {
        gameMenuCameraCanvasSystem.OpenTechTreeTab();
    }

    public void OpenMapTab()
    {
        gameMenuCameraCanvasSystem.OpenMapTab();
    }

    public void OpenLevelInfo(Level level)
    {
        cameraMovementOff();
        gameMenuLevelInfoSystem.OpenLevelInfo(level);
    }

    public void OpenTechInfo(Technology tech)
    {
        cameraMovementOff();
        gameMenuTechnologyInfoSystem.LoadTechInfo(tech);
    }

}
