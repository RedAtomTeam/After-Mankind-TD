using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologiesLinksSystem : MonoBehaviour
{
    [SerializeField] private List<TechnologyLink> techLinksList;

    public void FullUpdateTechTreeLinks()
    {
        foreach (TechnologyLink techLink in techLinksList)
        {
            techLink.UpdateStatus();
        }
    }
}
