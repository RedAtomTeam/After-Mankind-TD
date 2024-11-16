using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuTechnologyTreeSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuController gameMenuController;

    // Подсистемы
    [SerializeField] TechnologiesNodesSystem technologiesNodesSystem;
    [SerializeField] TechnologiesLinksSystem technologiesLinksSystem;
    [SerializeField] TechnologiesConnectorsSystem technologiesConnectorsSystem;

    [SerializeField] GameObject obj;

    // Функция открытия информации о технологии
    public void OpenTechInfo(Technology tech)
    {
        gameMenuController.OpenTechInfo(tech);
    }

    // Функция обновления дерева технологий
    public void FullUpdateTechTree()
    {
        technologiesNodesSystem.FullUpdateTechTreeNodes();
        technologiesLinksSystem.FullUpdateTechTreeLinks();
        technologiesConnectorsSystem.FullUpdateTechTreeConnectors();
    }

    // Функция открытия дерева технологий
    public void OpenTechTreeTab()
    {
        obj.SetActive(true);
    }

    // Функция закрытия дерева технологий
    public void CloseTechTreeTab()
    {
        obj.SetActive(false);
    }

}
