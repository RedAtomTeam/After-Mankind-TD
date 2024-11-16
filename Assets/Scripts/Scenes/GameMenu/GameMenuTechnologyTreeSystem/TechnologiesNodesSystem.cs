using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologiesNodesSystem : MonoBehaviour
{
    // ����������
    [SerializeField] GameMenuTechnologyTreeSystem gameMenuTechnologyTreeSystem;


    [SerializeField] List<TechnologyNode> techNodesList;

    // ������� ���������� ���� ���
    public void FullUpdateTechTreeNodes()
    {
        foreach (TechnologyNode techNode in techNodesList)
        {
            techNode.UpdateStatus();
        }
    }

    // ������� �������� ���������� � ����������
    public void OpenTechInfo(Technology tech)
    {
        gameMenuTechnologyTreeSystem.OpenTechInfo(tech);
    }

}
