using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMapLink : MonoBehaviour
{
    // Менеджер сохранений
    GameManager gameManager;

    // Надсистемы
    [SerializeField] LevelsLinksSystem levelsLinksSystem;

    // Подсистемы
    [SerializeField] LevelLinkVisualController visualController;

    // Вунтренние переменные
    [SerializeField] LevelMapNode firstLevelNode;
    [SerializeField] LevelMapNode secondLevelNode;
    [SerializeField] int status = 0;
    [SerializeField] RectTransform lineImage; 
    [SerializeField] float lineWidth;
    
    Level levelEntityPrev;
    Level levelEntityNext;
    RectTransform pointA; 
    RectTransform pointB; 

    private void Start()
    {
        levelEntityPrev = firstLevelNode.levelEntity;
        levelEntityNext = secondLevelNode.levelEntity;

        pointA = firstLevelNode.gameObject.GetComponent<RectTransform>();
        pointB = secondLevelNode.gameObject.GetComponent<RectTransform>();

        gameManager = GameManager.Instance;
        DrawLine(pointA.anchoredPosition, pointB.anchoredPosition);
    }

    // Функция позиционирования линии
    void DrawLine(Vector2 start, Vector2 end)
    {
        lineImage.anchoredPosition = new Vector2((start.x + end.x)/2, (start.y + end.y)/2);

        Vector2 direction = end - start; // Разница между конечной и начальной точками
        lineImage.sizeDelta = new Vector2(direction.magnitude, lineImage.sizeDelta.y * lineWidth); // Установка длины линии

        // Установка угла поворота
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        lineImage.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Функция обновления статуса
    public void UpdateStatus()
    {
        int prevID = levelEntityPrev.ID;
        int nextID = levelEntityNext.ID;
       
        foreach (LevelData levelData in gameManager.playerGameData.levels)
        {
            if (levelData.ID == nextID)
            {
                status = (levelData.status >= status ? levelData.status : status);
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
        visualController.SetPassed();
    }

    // Функция установки состояни Opened
    public void SetOpened()
    {
        visualController.SetOpened();
    }

    // Функция установки состояни Closed
    public void SetClosed()
    {
        visualController.SetClosed();
    }
}
