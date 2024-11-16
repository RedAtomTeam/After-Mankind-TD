using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuLevelsMapSystem : MonoBehaviour
{
    // ����������
    [SerializeField] GameMenuController gameMenuController;

    // ����������
    [SerializeField] LevelsNodesSystem nodesSystem;
    [SerializeField] LevelsLinksSystem linksSystem;

    // ���������� ����������
    [SerializeField] GameObject obj;

    // ������� �������� ���������� �� ������
    public void OpenLevelInfo(Level level)
    {
        gameMenuController.OpenLevelInfo(level);
    }

    // ������� ���������� ����� �������
    public void FullUpdateMap()
    {
        nodesSystem.FullUpdateNodes();
        linksSystem.FullUpdateLinks();
    }

    // ������� �������� ����� �������
    public void OpenMapTab()
    {
        obj.SetActive(true);
    }

    // ������� �������� ����� �������
    public void CloseMapTab()
    {
        obj.SetActive(false);
    }
}
