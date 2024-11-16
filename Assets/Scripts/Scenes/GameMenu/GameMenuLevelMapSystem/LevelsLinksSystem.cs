using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsLinksSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuLevelsMapSystem gameMenuLevelsMapSystem;

    [SerializeField] List<LevelMapLink> linksList;

    // Функция обновления связей между уровнями
    public void FullUpdateLinks()
    {
        foreach (LevelMapLink levelLink in linksList)
        {
            levelLink.UpdateStatus();
        }
    }
}
