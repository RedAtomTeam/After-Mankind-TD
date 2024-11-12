using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologiesNodesSystem : MonoBehaviour
{

    [SerializeField] private List<TechnologyNode> techNodesList;

    [SerializeField] private GameMenuTechnologyTreeSystem gameMenuTechnologyTreeSystem;

    public void FullUpdateTechTreeNodes()
    {
        foreach (TechnologyNode techNode in techNodesList)
        {
            techNode.UpdateStatus();
        }
    }

    public void OpenTechInfo(Technology tech)
    {
        gameMenuTechnologyTreeSystem.OpenTechInfo(tech);
    }

}
