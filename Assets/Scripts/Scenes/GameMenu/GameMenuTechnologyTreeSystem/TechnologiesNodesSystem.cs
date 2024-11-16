using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologiesNodesSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuTechnologyTreeSystem gameMenuTechnologyTreeSystem;


    [SerializeField] List<TechnologyNode> techNodesList;

    // Функция обновления всех нод
    public void FullUpdateTechTreeNodes()
    {
        foreach (TechnologyNode techNode in techNodesList)
        {
            techNode.UpdateStatus();
        }
    }

    // Функция открытия информации о технологии
    public void OpenTechInfo(Technology tech)
    {
        gameMenuTechnologyTreeSystem.OpenTechInfo(tech);
    }

}
