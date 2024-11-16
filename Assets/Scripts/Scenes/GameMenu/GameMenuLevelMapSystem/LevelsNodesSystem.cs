using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsNodesSystem : MonoBehaviour
{
    // ����������
    [SerializeField] GameMenuLevelsMapSystem gameMenuLevelsMapSystem;

    // ���������� ����������
    [SerializeField] List<LevelMapNode> levelNodesList;

    // ������� �������� ���������� �� ������
    public void OpenLevelInfo(Level levelEntity)
    {
        gameMenuLevelsMapSystem.OpenLevelInfo(levelEntity);
    }

    // ������� ���������� ���� ���
    public void FullUpdateNodes()
    {
        foreach (LevelMapNode levelNode in levelNodesList)
        {
            levelNode.UpdateStatus();
        }
    }
}
