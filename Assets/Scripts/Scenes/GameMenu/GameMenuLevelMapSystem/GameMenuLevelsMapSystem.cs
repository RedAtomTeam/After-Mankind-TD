using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuLevelsMapSystem : MonoBehaviour
{
    [SerializeField] private GameMenuController gameMenuController;


    [SerializeField] private LevelsNodesSystem nodesSystem;
    [SerializeField] private LevelsLinksSystem linksSystem;

    [SerializeField] private GameObject obj;

    public void OpenLevelInfo(Level level)
    {
        gameMenuController.OpenLevelInfo(level);
    }


    public void FullUpdateMap()
    {
        nodesSystem.FullUpdateNodes();
        linksSystem.FullUpdateLinks();
    }


    public void OpenMapTab()
    {
        print(1);
        obj.SetActive(true);
    }

    public void CloseMapTab()
    {
        obj.SetActive(false);
    }
}
