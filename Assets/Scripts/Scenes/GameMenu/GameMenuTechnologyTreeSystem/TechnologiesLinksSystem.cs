using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologiesLinksSystem : MonoBehaviour
{
    
    [SerializeField] List<TechnologyLink> techLinksList;

    // Функция обновления связей дерева технологий
    public void FullUpdateTechTreeLinks()
    {
        foreach (TechnologyLink techLink in techLinksList)
        {
            techLink.UpdateStatus();
        }
    }
}
