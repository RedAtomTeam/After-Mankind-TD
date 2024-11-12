using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuTechnologyTreeSystem : MonoBehaviour
{
    [SerializeField] private GameMenuController gameMenuController;

    [SerializeField] private TechnologiesNodesSystem technologiesNodesSystem;
    [SerializeField] private TechnologiesLinksSystem technologiesLinksSystem;
    [SerializeField] private TechnologiesConnectorsSystem technologiesConnectorsSystem;

    [SerializeField] private GameObject obj;

    public void OpenTechInfo(Technology tech)
    {
        gameMenuController.OpenTechInfo(tech);
    }

    public void FullUpdateTechTree()
    {
        technologiesNodesSystem.FullUpdateTechTreeNodes();
        technologiesLinksSystem.FullUpdateTechTreeLinks();
        technologiesConnectorsSystem.FullUpdateTechTreeConnectors();
    }

    public void OpenTechTreeTab()
    {
        print(2);
        obj.SetActive(true);
    }

    public void CloseTechTreeTab()
    {
        obj.SetActive(false);
    }

}
