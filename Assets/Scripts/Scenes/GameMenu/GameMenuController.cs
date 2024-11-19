using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    GameManager gameManager;

    // Подсистемы 
    [SerializeField] GameMenuCameraCanvasSystem cameraCanvasSystem;
    [SerializeField] GameMenuCameraSystem cameraSystem;
    [SerializeField] GameMenuLevelsMapSystem levelsMapSystem;
    [SerializeField] GameMenuTechnologyTreeSystem technologyTreeSystem;
    [SerializeField] LoadingScreenSystem_MainScript loadingScreenSystem;

    public void LoadScene(string sceneName)
    {
        loadingScreenSystem.LoadScene(sceneName);
    }

    public void UpdateLearnPoints()
    {
        int points = gameManager.playerGameData.balanceData.Balance;
        cameraCanvasSystem.UpdateLearnPoints(points);
    }

    private void Start()
    {
        gameManager = GameManager.Instance;

        FullUpdateLevelMap();
        OpenMapTab();
        FullUpdateTechTree();
        UpdateLearnPoints();
    }

    // Функция включения движения камеры
    public void cameraMovementOn()
    {
        cameraSystem.cameraIsOn = true;
    }

    // Функция выключения движения камеры
    public void cameraMovementOff()
    {
        cameraSystem.cameraIsOn = false;
    }

    // Функция открытия информации о технологии
    public void OpenTechInfo(Technology tech)
    {
        cameraCanvasSystem.OpenTechInfo(tech);
    }

    // Функция открытия информации об уровне
    public void OpenLevelInfo(Level level)
    {
        cameraCanvasSystem.OpenLevelInfo(level);
    }

    // Функция обновления карты уровней
    public void FullUpdateLevelMap()
    {
        levelsMapSystem.FullUpdateMap();
    }

    // Функция обновления дерева технологий
    public void FullUpdateTechTree()
    {
        technologyTreeSystem.FullUpdateTechTree();
    }


    // Функция открытия карты уровней
    public void OpenMapTab()
    {
        cameraSystem.SetPositionOnStartPosition();
        cameraSystem.ChooseSpriteRendererMap();
        levelsMapSystem.OpenMapTab();
        CloseTechTreeTab();
    }

    // Функция закрытия карты уровней
    public void CloseMapTab()
    {
        levelsMapSystem.CloseMapTab();
    }

    // Функция открытия дерева технологий
    public void OpenTechTreeTab()
    {
        cameraSystem.SetPositionOnStartPosition();
        cameraSystem.ChooseSpriteRendererTech();
        technologyTreeSystem.OpenTechTreeTab();
        CloseMapTab();
    }

    // Функция закрытия дерева технологий
    public void CloseTechTreeTab()
    {
        technologyTreeSystem.CloseTechTreeTab();
    }

}
