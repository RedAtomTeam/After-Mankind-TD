using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyNode : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private TechnologiesNodesSystem technologiesNodesSystem;
    [SerializeField] private TechnologyNodeVisualController visualController;

    [SerializeField] private Technology technologyEntity;
    [SerializeField] private int status;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public void Click()
    {
        OpenTechInfo();
    }

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

    public void OpenTechInfo()
    {
        technologiesNodesSystem.OpenTechInfo(technologyEntity);
    }

    public void SetLearned()
    {
        visualController.SetLearned();
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
