using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuTechnologyTreeSystem : MonoBehaviour
{
    // ����������
    [SerializeField] GameMenuController gameMenuController;

    // ����������
    [SerializeField] TechnologiesNodesSystem technologiesNodesSystem;
    [SerializeField] TechnologiesLinksSystem technologiesLinksSystem;
    [SerializeField] TechnologiesConnectorsSystem technologiesConnectorsSystem;

    [SerializeField] GameObject obj;

    // ������� �������� ���������� � ����������
    public void OpenTechInfo(Technology tech)
    {
        gameMenuController.OpenTechInfo(tech);
    }

    // ������� ���������� ������ ����������
    public void FullUpdateTechTree()
    {
        technologiesNodesSystem.FullUpdateTechTreeNodes();
        technologiesLinksSystem.FullUpdateTechTreeLinks();
        technologiesConnectorsSystem.FullUpdateTechTreeConnectors();
    }

    // ������� �������� ������ ����������
    public void OpenTechTreeTab()
    {
        obj.SetActive(true);
    }

    // ������� �������� ������ ����������
    public void CloseTechTreeTab()
    {
        obj.SetActive(false);
    }

}
