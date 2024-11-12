using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapNode : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private LevelsNodesSystem levelsNodesSystem;

    [SerializeField] public Level levelEntity;
    [SerializeField] private int status;
    [SerializeField] private LevelNodeVisualController levelNodeVisualController;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    
    public void Click()
    {
        OpenLevelInfo();
    }

    public void OpenLevelInfo()
    {
        levelsNodesSystem.OpenLevelInfo(levelEntity);
    }

    public void UpdateStatus()
    {
        int currentID = levelEntity.ID;
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
    public void SetPassed()
    {
        levelNodeVisualController.SetPassed();
    }

    public void SetOpened()
    {
        levelNodeVisualController.SetOpened();
    }

    public void SetClosed()
    {
        levelNodeVisualController.SetClosed();
    }
}
