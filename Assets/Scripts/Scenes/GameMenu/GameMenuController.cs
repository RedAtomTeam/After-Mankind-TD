using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    // ���������� 

    [SerializeField] GameMenuCameraCanvasSystem cameraCanvasSystem;
    [SerializeField] GameMenuCameraSystem cameraSystem;
    [SerializeField] GameMenuLevelsMapSystem levelsMapSystem;
    [SerializeField] GameMenuTechnologyTreeSystem technologyTreeSystem;
    [SerializeField] LoadingScreenSystem_MainScript loadingScreenSystem;
    
    
    private void Start()
    {
        FullUpdateLevelMap();
        OpenMapTab();
        FullUpdateTechTree();
    }

    // ������� ��������� �������� ������
    public void cameraMovementOn()
    {
        cameraSystem.cameraIsOn = true;
    }

    // ������� ���������� �������� ������
    public void cameraMovementOff()
    {
        cameraSystem.cameraIsOn = false;
    }

    // ������� �������� ���������� � ����������
    public void OpenTechInfo(Technology tech)
    {
        cameraCanvasSystem.OpenTechInfo(tech);
    }

    // ������� �������� ���������� �� ������
    public void OpenLevelInfo(Level level)
    {
        cameraCanvasSystem.OpenLevelInfo(level);
    }

    // ������� ���������� ����� �������
    public void FullUpdateLevelMap()
    {
        levelsMapSystem.FullUpdateMap();
    }

    // ������� ���������� ������ ����������
    public void FullUpdateTechTree()
    {
        technologyTreeSystem.FullUpdateTechTree();
    }


    // ������� �������� ����� �������
    public void OpenMapTab()
    {
        cameraSystem.SetPositionOnStartPosition();
        cameraSystem.ChangeSpriteRenderer();
        levelsMapSystem.OpenMapTab();
        CloseTechTreeTab();
    }

    // ������� �������� ����� �������
    public void CloseMapTab()
    {
        levelsMapSystem.CloseMapTab();
    }

    // ������� �������� ������ ����������
    public void OpenTechTreeTab()
    {
        cameraSystem.SetPositionOnStartPosition();
        cameraSystem.ChangeSpriteRenderer();
        technologyTreeSystem.OpenTechTreeTab();
        CloseMapTab();
    }

    // ������� �������� ������ ����������
    public void CloseTechTreeTab()
    {
        technologyTreeSystem.CloseTechTreeTab();
    }

}
