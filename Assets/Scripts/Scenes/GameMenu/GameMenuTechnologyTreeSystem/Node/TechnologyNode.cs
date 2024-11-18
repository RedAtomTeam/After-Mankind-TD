using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyNode : MonoBehaviour
{
    // Менеджер сохранений
    GameManager gameManager;

    // Надсистемы
    [SerializeField] TechnologiesNodesSystem technologiesNodesSystem;
    
    // Подсистемы
    [SerializeField] TechnologyNodeVisualController visualController;

    [SerializeField] public Technology technologyEntity;
    [SerializeField] int status;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    // Функция клика
    public void Click()
    {
        OpenTechInfo();
    }

    // Функция обновления статуса
    public void UpdateStatus()
    {
        int currentID = technologyEntity.ID;
        foreach (TechnologyData techData in gameManager.playerGameData.technologies)
        {
            if (techData.ID == currentID)
            {
                status = techData.status;
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
                SetLearned();
                break;
        }
    }

    // Функция открытия информации о технологии
    public void OpenTechInfo()
    {
        technologiesNodesSystem.OpenTechInfo(technologyEntity);
    }

    // Функция изучения
    public void SetLearned()
    {
        visualController.SetLearned();
    }

    // Функция открытия
    public void SetOpened()
    {
        visualController.SetOpened();
    }

    // Функция закрытия
    public void SetClosed()
    {
        visualController.SetClosed();
    }
}
