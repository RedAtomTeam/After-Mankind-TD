using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologiesConnectorsSystem : MonoBehaviour
{
    // Подсистемы   
    [SerializeField] List<TechnologyConnector> techConnectorsList;

    // Функция для полного обновления всех коннекторов
    public void FullUpdateTechTreeConnectors()
    {
        foreach (TechnologyConnector techConnector in techConnectorsList)
        {
            techConnector.UpdateStatus();
        }
    }
}
