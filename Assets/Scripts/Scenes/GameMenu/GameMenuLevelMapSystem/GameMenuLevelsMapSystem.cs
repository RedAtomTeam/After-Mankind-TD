using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuLevelsMapSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuController gameMenuController;

    // Подсистемы
    [SerializeField] LevelsNodesSystem nodesSystem;
    [SerializeField] LevelsLinksSystem linksSystem;

    // Внутренние переменные
    [SerializeField] GameObject obj;

    // Функция открытия информации об уровне
    public void OpenLevelInfo(Level level)
    {
        gameMenuController.OpenLevelInfo(level);
    }

    // Функция обновления карты уровней
    public void FullUpdateMap()
    {
        nodesSystem.FullUpdateNodes();
        linksSystem.FullUpdateLinks();
    }

    // Функция открытия карты урвоней
    public void OpenMapTab()
    {
        obj.SetActive(true);
    }

    // Функция закрытия карты уровней
    public void CloseMapTab()
    {
        obj.SetActive(false);
    }
}
