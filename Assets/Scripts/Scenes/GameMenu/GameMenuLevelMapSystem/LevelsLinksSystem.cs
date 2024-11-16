using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsLinksSystem : MonoBehaviour
{
    // ����������
    [SerializeField] GameMenuLevelsMapSystem gameMenuLevelsMapSystem;

    [SerializeField] List<LevelMapLink> linksList;

    // ������� ���������� ������ ����� ��������
    public void FullUpdateLinks()
    {
        foreach (LevelMapLink levelLink in linksList)
        {
            levelLink.UpdateStatus();
        }
    }
}
