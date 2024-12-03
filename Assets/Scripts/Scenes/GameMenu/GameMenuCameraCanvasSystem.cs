using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuCameraCanvasSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuController gameMenuController;

    // Подсистемы
    [SerializeField] GameMenuInterfaceSystem gameMenuInterfaceSystem;

    // Функция загрузки сцены
    public void LoadScene(string sceneName)
    {
        gameMenuController.LoadScene(sceneName);
    }

    // Функция обновления карты уровней
    public void FullUpdateLevelMap()
    {
        gameMenuController.FullUpdateLevelMap();
    }

    // Функция обновления дерева технологий
    public void FullUpdateTechTree()
    {
        gameMenuController.FullUpdateTechTree();
    }

    // Функция обновления очков изучения
    public void UpdateLearnPoints(int points)
    {
        gameMenuInterfaceSystem.UpdateLearnPoints(points);
    }

    // Функция включения камеры
    public void cameraMovementOn()
    {
        gameMenuController.cameraMovementOn();
    }

    // Функция выключения камеры
    public void cameraMovementOff()
    {
        gameMenuController.cameraMovementOff();
    }

    // Функция открытия информации об уровне
    public void OpenLevelInfo(Level level)
    {
        gameMenuInterfaceSystem.OpenLevelInfo(level);
    }

    // Функция открытия информации о технологии
    public void OpenTechInfo(Technology tech)
    {
        gameMenuInterfaceSystem.OpenTechInfo(tech);
    }

    // Функция открытия дерева технологий
    public void OpenTechTreeTab() 
    {
        gameMenuController.OpenTechTreeTab();
    }

    // Функция открытия карты уровней
    public void OpenMapTab()
    {
        gameMenuController.OpenMapTab();
    }
}
