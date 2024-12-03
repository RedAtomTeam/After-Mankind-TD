using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenuInterfaceSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuCameraCanvasSystem gameMenuCameraCanvasSystem;

    // Подсистемы
    [SerializeField] GameMenuLevelInfoSystem gameMenuLevelInfoSystem;
    [SerializeField] GameMenuTechnologyInfoSystem gameMenuTechnologyInfoSystem;

    [SerializeField] TextMeshProUGUI learnPointTMP;

    public void LoadScene(string sceneName)
    {
        gameMenuCameraCanvasSystem.LoadScene(sceneName);
    }

    // Функция обновления карты уровней
    public void FullUpdateLevelMap()
    {
        gameMenuCameraCanvasSystem.FullUpdateLevelMap();
    }

    // Функция обновления дерева технологий
    public void FullUpdateTechTree()
    {
        gameMenuCameraCanvasSystem.FullUpdateTechTree();
    }

    public void UpdateLearnPoints(int points)
    {
        learnPointTMP.text = points.ToString();
    }

    // Функция включения камеры
    public void cameraMovementOn()
    {
        gameMenuCameraCanvasSystem.cameraMovementOn();
    }

    // Функция выключения камеры
    public void cameraMovementOff()
    {
        gameMenuCameraCanvasSystem.cameraMovementOff();
    }

    // Функция запуска уровня
    public void StartLevel(int ID)
    {

    }

    // Функция открытия дерева технологий
    public void OpenTechTreeTab()
    {
        gameMenuCameraCanvasSystem.OpenTechTreeTab();
    }

    // Функция открытия карты уровней
    public void OpenMapTab()
    {
        gameMenuCameraCanvasSystem.OpenMapTab();
    }

    // Функция открытия информации об уровне
    public void OpenLevelInfo(Level level)
    {
        cameraMovementOff();
        gameMenuLevelInfoSystem.OpenLevelInfo(level);
    }

    // Функция открытия информации о технологии
    public void OpenTechInfo(Technology tech)
    {
        cameraMovementOff();
        gameMenuTechnologyInfoSystem.LoadTechInfo(tech);
    }

}
