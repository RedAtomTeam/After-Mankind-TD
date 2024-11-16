using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuCameraCanvasSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuController gameMenuController;

    // Подсистемы
    [SerializeField] GameMenuInterfaceSystem gameMenuInterfaceSystem;


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
