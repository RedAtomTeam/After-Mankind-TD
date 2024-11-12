using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMapLink : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private LevelsLinksSystem levelsLinksSystem;
    [SerializeField] private LevelMapNode firstLevelNode;
    [SerializeField] private LevelMapNode secondLevelNode;
    [SerializeField] private int status = 0;
    [SerializeField] private RectTransform lineImage; // Задайте в инспекторе
    [SerializeField] private float lineWidth;
    [SerializeField] private LevelLinkVisualController visualController;
    
    private Level levelEntityPrev;
    private Level levelEntityNext;
    private RectTransform pointA; // Задайте в инспекторе
    private RectTransform pointB; // Задайте в инспекторе

    private void Start()
    {
        levelEntityPrev = firstLevelNode.levelEntity;
        levelEntityNext = secondLevelNode.levelEntity;

        pointA = firstLevelNode.gameObject.GetComponent<RectTransform>();
        pointB = secondLevelNode.gameObject.GetComponent<RectTransform>();

        gameManager = GameManager.Instance;
        DrawLine(pointA.anchoredPosition, pointB.anchoredPosition);
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        lineImage.anchoredPosition = new Vector2((start.x + end.x)/2, (start.y + end.y)/2);

        //lineImage.anchoredPosition = start; // Установка начальной позиции линии
        Vector2 direction = end - start; // Разница между конечной и начальной точками
        lineImage.sizeDelta = new Vector2(direction.magnitude, lineImage.sizeDelta.y * lineWidth); // Установка длины линии

        // Установка угла поворота
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        lineImage.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void UpdateStatus()
    {
        int prevID = levelEntityPrev.ID;
        int nextID = levelEntityNext.ID;
       
        foreach (LevelData levelData in gameManager.playerGameData.levels)
        {
            //if (levelData.ID == prevID)
            //{
            //    status = (levelData.status >= status ? levelData.status : status);
            //}
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
    public void SetPassed()
    {
        visualController.SetPassed();
    }

    public void SetOpened()
    {
        visualController.SetOpened();
    }

    public void SetClosed()
    {
        visualController.SetClosed();
    }
}
