using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryInterfaceSystem : MonoBehaviour
{
    [SerializeField] private GlossaryController controller;

    [SerializeField] private GlossaryEnemyInfoSystem glossaryEnemyInfo;
    [SerializeField] private GlossaryEnemiesListSystem glossaryEnemiesList;

    public void SetDataAboutEnemy(Enemy EnemySO)
    {
        glossaryEnemyInfo.SetInfoAboutEnemy(EnemySO);
    }

    public void LoadScene(string sceneName)
    {
        controller.LoadScene(sceneName);
    }
}
