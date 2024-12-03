using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapNode : MonoBehaviour
{
    // Менеджер сохранений
    GameManager gameManager;

    // Надсистемы
    [SerializeField] LevelsNodesSystem levelsNodesSystem;

    // Подсистемы
    [SerializeField] LevelNodeVisualController levelNodeVisualController;

    public Level levelEntity;
    [SerializeField] int status;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }
    
    // Функция для клика по кнопке уровня
    public void Click()
    {
        OpenLevelInfo();
    }

    // Функция открытия информации об уровне
    public void OpenLevelInfo()
    {
        levelsNodesSystem.OpenLevelInfo(levelEntity);
    }

    // Функция обновления состояния ноды
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

    // Функция установки состояни Passed
    public void SetPassed()
    {
        levelNodeVisualController.SetPassed();
    }

    // Функция установки состояни Opened
    public void SetOpened()
    {
        levelNodeVisualController.SetOpened();
    }

    // Функция установки состояни Closed
    public void SetClosed()
    {
        levelNodeVisualController.SetClosed();
    }
}
