using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsNodesSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuLevelsMapSystem gameMenuLevelsMapSystem;

    // Внутренние переменные
    [SerializeField] List<LevelMapNode> levelNodesList;

    // Функция открытия информации об уровне
    public void OpenLevelInfo(Level levelEntity)
    {
        gameMenuLevelsMapSystem.OpenLevelInfo(levelEntity);
    }

    // Функция обновления всех нод
    public void FullUpdateNodes()
    {
        foreach (LevelMapNode levelNode in levelNodesList)
        {
            levelNode.UpdateStatus();
        }
    }
}
