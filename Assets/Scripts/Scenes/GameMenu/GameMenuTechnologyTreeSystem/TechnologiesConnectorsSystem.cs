using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologiesConnectorsSystem : MonoBehaviour
{
    // ����������   
    [SerializeField] List<TechnologyConnector> techConnectorsList;

    // ������� ��� ������� ���������� ���� �����������
    public void FullUpdateTechTreeConnectors()
    {
        foreach (TechnologyConnector techConnector in techConnectorsList)
        {
            techConnector.UpdateStatus();
        }
    }
}
