using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private GameMenuCameraCanvasSystem cameraCanvasSystem;
    [SerializeField] private GameMenuCameraSystem cameraSystem;
    [SerializeField] private GameMenuLevelsMapSystem levelsMapSystem;
    [SerializeField] private GameMenuTechnologyTreeSystem technologyTreeSystem;
    [SerializeField] private LoadingScreenSystem_MainScript loadingScreenSystem;


    public void cameraMovementOn()
    {
        cameraSystem.cameraIsOn = true;
    }

    public void cameraMovementOff()
    {
        cameraSystem.cameraIsOn = false;
    }

    private void Start()
    {
        FullUpdateLevelMap();
        OpenMapTab();
        FullUpdateTechTree();
    }

    public void OpenTechInfo(Technology tech)
    {
        cameraCanvasSystem.OpenTechInfo(tech);
    }

    public void FullUpdateLevelMap()
    {
        levelsMapSystem.FullUpdateMap();
    }

    public void FullUpdateTechTree()
    {
        technologyTreeSystem.FullUpdateTechTree();
    }


    public void OpenLevelInfo(Level level)
    {
        cameraCanvasSystem.OpenLevelInfo(level);
    }

    public void OpenMapTab()
    {
        cameraSystem.SetPositionOnStartPosition();
        levelsMapSystem.OpenMapTab();
        CloseTechTreeTab();
    }

    public void CloseMapTab()
    {
        levelsMapSystem.CloseMapTab();
    }

    public void OpenTechTreeTab()
    {
        cameraSystem.SetPositionOnStartPosition();
        technologyTreeSystem.OpenTechTreeTab();
        CloseMapTab();
    }

    public void CloseTechTreeTab()
    {
        technologyTreeSystem.CloseTechTreeTab();
    }

}
