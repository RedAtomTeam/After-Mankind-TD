using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuCameraCanvasSystem : MonoBehaviour
{
    // ����������
    [SerializeField] GameMenuController gameMenuController;

    // ����������
    [SerializeField] GameMenuInterfaceSystem gameMenuInterfaceSystem;

    // ������� �������� �����
    public void LoadScene(string sceneName)
    {
        gameMenuController.LoadScene(sceneName);
    }

    // ������� ���������� ����� �������
    public void FullUpdateLevelMap()
    {
        gameMenuController.FullUpdateLevelMap();
    }

    // ������� ���������� ������ ����������
    public void FullUpdateTechTree()
    {
        gameMenuController.FullUpdateTechTree();
    }

    // ������� ���������� ����� ��������
    public void UpdateLearnPoints(int points)
    {
        gameMenuInterfaceSystem.UpdateLearnPoints(points);
    }

    // ������� ��������� ������
    public void cameraMovementOn()
    {
        gameMenuController.cameraMovementOn();
    }

    // ������� ���������� ������
    public void cameraMovementOff()
    {
        gameMenuController.cameraMovementOff();
    }

    // ������� �������� ���������� �� ������
    public void OpenLevelInfo(Level level)
    {
        gameMenuInterfaceSystem.OpenLevelInfo(level);
    }

    // ������� �������� ���������� � ����������
    public void OpenTechInfo(Technology tech)
    {
        gameMenuInterfaceSystem.OpenTechInfo(tech);
    }

    // ������� �������� ������ ����������
    public void OpenTechTreeTab() 
    {
        gameMenuController.OpenTechTreeTab();
    }

    // ������� �������� ����� �������
    public void OpenMapTab()
    {
        gameMenuController.OpenMapTab();
    }
}
