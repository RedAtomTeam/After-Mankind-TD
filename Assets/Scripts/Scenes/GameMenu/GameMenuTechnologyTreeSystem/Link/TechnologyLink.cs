using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyLink : MonoBehaviour
{
    // Менеджер сохранений
    GameManager gameManager;

    // Надсистемы
    [SerializeField] TechnologiesLinksSystem technologiesLinksSystem;

    // Подсистемы
    [SerializeField] TechnologyLinkVisualController visualController;
    
    [SerializeField] int status = 0;
    [SerializeField] RectTransform lineImage; // Задайте в инспекторе
    [SerializeField] float lineWidth;
    [SerializeField] List<Technology> techEntityPrevs;
    [SerializeField] List<Technology> techEntityNext;
    [SerializeField] RectTransform pointA; // Задайте в инспекторе
    [SerializeField] RectTransform pointB; // Задайте в инспекторе

    private void Awake()
    {
        gameManager = GameManager.Instance;
        DrawLine(pointA.anchoredPosition, pointB.anchoredPosition);
    }

    // Функция позиционирования объекта
    void DrawLine(Vector2 start, Vector2 end)
    {
        lineImage.anchoredPosition = new Vector2((start.x + end.x) / 2, (start.y + end.y) / 2);

        //lineImage.anchoredPosition = start; // Установка начальной позиции линии
        Vector2 direction = end - start; // Разница между конечной и начальной точками
        lineImage.sizeDelta = new Vector2(direction.magnitude, lineImage.sizeDelta.y * lineWidth); // Установка длины линии

        // Установка угла поворота
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        lineImage.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Функция обновления статуса
    public void UpdateStatus()
    {
        foreach (Technology tech in techEntityNext)
        {
            foreach (TechnologyData techData in gameManager.playerGameData.technologies)
            {
                if (tech.ID == techData.ID)
                {
                    status = (techData.status >= status ? techData.status : status);
                }
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

    // Функция установки статуса Passed
    public void SetPassed()
    {
        visualController.SetPassed();
    }

    // Функция установки статуса Opened
    public void SetOpened()
    {
        visualController.SetOpened();
    }

    // Функция установки статуса Closed
    public void SetClosed()
    {
        visualController.SetClosed();
    }
}
