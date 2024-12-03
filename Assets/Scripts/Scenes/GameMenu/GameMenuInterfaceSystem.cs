using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenuInterfaceSystem : MonoBehaviour
{
    // ����������
    [SerializeField] GameMenuCameraCanvasSystem gameMenuCameraCanvasSystem;

    // ����������
    [SerializeField] GameMenuLevelInfoSystem gameMenuLevelInfoSystem;
    [SerializeField] GameMenuTechnologyInfoSystem gameMenuTechnologyInfoSystem;

    [SerializeField] TextMeshProUGUI learnPointTMP;

    public void LoadScene(string sceneName)
    {
        gameMenuCameraCanvasSystem.LoadScene(sceneName);
    }

    // ������� ���������� ����� �������
    public void FullUpdateLevelMap()
    {
        gameMenuCameraCanvasSystem.FullUpdateLevelMap();
    }

    // ������� ���������� ������ ����������
    public void FullUpdateTechTree()
    {
        gameMenuCameraCanvasSystem.FullUpdateTechTree();
    }

    public void UpdateLearnPoints(int points)
    {
        learnPointTMP.text = points.ToString();
    }

    // ������� ��������� ������
    public void cameraMovementOn()
    {
        gameMenuCameraCanvasSystem.cameraMovementOn();
    }

    // ������� ���������� ������
    public void cameraMovementOff()
    {
        gameMenuCameraCanvasSystem.cameraMovementOff();
    }

    // ������� ������� ������
    public void StartLevel(int ID)
    {

    }

    // ������� �������� ������ ����������
    public void OpenTechTreeTab()
    {
        gameMenuCameraCanvasSystem.OpenTechTreeTab();
    }

    // ������� �������� ����� �������
    public void OpenMapTab()
    {
        gameMenuCameraCanvasSystem.OpenMapTab();
    }

    // ������� �������� ���������� �� ������
    public void OpenLevelInfo(Level level)
    {
        cameraMovementOff();
        gameMenuLevelInfoSystem.OpenLevelInfo(level);
    }

    // ������� �������� ���������� � ����������
    public void OpenTechInfo(Technology tech)
    {
        cameraMovementOff();
        gameMenuTechnologyInfoSystem.LoadTechInfo(tech);
    }

}
