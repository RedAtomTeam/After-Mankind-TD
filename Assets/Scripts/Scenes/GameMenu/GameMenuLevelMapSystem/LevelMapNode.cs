using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapNode : MonoBehaviour
{
    // �������� ����������
    GameManager gameManager;

    // ����������
    [SerializeField] LevelsNodesSystem levelsNodesSystem;

    // ����������
    [SerializeField] LevelNodeVisualController levelNodeVisualController;

    public Level levelEntity;
    [SerializeField] int status;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }
    
    // ������� ��� ����� �� ������ ������
    public void Click()
    {
        OpenLevelInfo();
    }

    // ������� �������� ���������� �� ������
    public void OpenLevelInfo()
    {
        levelsNodesSystem.OpenLevelInfo(levelEntity);
    }

    // ������� ���������� ��������� ����
    public void UpdateStatus()
    {
        int currentID = levelEntity.ID;

        if (gameManager == null)
        {
            gameManager = GameManager.Instance;
        }

        foreach (LevelData levelData in gameManager.playerGameData.levels) {
            if (levelData.ID == currentID) 
            {
                status = levelData.status;
                break;
            }
        }
        switch (status)
        {
            case 0:
                SetClosed();
                break;
            case 1:
                SetOpened();
                break;
            case 2:
                SetPassed();
                break;
        }
    }

    // ������� ��������� �������� Passed
    public void SetPassed()
    {
        levelNodeVisualController.SetPassed();
    }

    // ������� ��������� �������� Opened
    public void SetOpened()
    {
        levelNodeVisualController.SetOpened();
    }

    // ������� ��������� �������� Closed
    public void SetClosed()
    {
        levelNodeVisualController.SetClosed();
    }
}
