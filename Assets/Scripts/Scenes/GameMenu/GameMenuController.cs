using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    GameManager gameManager;

    // ���������� 
    [SerializeField] GameMenuCameraCanvasSystem cameraCanvasSystem;
    [SerializeField] GameMenuCameraSystem cameraSystem;
    [SerializeField] GameMenuLevelsMapSystem levelsMapSystem;
    [SerializeField] GameMenuTechnologyTreeSystem technologyTreeSystem;
    [SerializeField] LoadingScreenSystem_MainScript loadingScreenSystem;

    public void LoadScene(string sceneName)
    {
        loadingScreenSystem.LoadScene(sceneName);
    }

    public void UpdateLearnPoints()
    {
        int points = gameManager.playerGameData.balanceData.Balance;
        cameraCanvasSystem.UpdateLearnPoints(points);
    }

    private void Start()
    {
        gameManager = GameManager.Instance;

        FullUpdateLevelMap();
        OpenMapTab();
        FullUpdateTechTree();
        UpdateLearnPoints();
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
        cameraSystem.ChooseSpriteRendererMap();
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
        cameraSystem.ChooseSpriteRendererTech();
        technologyTreeSystem.OpenTechTreeTab();
        CloseMapTab();
    }

    // ������� �������� ������ ����������
    public void CloseTechTreeTab()
    {
        technologyTreeSystem.CloseTechTreeTab();
    }

}
