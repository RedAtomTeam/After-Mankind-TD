using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyConnector : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private TechnologiesConnectorsSystem technologiesConnectorsSystem;
    [SerializeField] private TechnologyConnectorVisualController visualController;

    [SerializeField] private List<Technology> techEntityPrevs;
    [SerializeField] private List<Technology> techEntityNext;

    private int status;

    private void Start()
    {
        gameManager = GameManager.Instance;
        UpdateStatus();
    }

    public void UpdateStatus()
    {
        foreach (Technology tech in techEntityNext)
        {
            int nextID = tech.ID;

            foreach (LevelData levelData in gameManager.playerGameData.levels)
            {
                if (levelData.ID == nextID)
                {
                    status = (levelData.status >= status ? levelData.status : status);
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
