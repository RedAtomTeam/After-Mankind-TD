using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryInterfaceSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GlossaryController controller;

    // Подсистемы
    [SerializeField] GlossaryEnemyInfoSystem glossaryEnemyInfo;
    [SerializeField] GlossaryEnemiesListSystem glossaryEnemiesList;

    // Функция установки информации о противнике в окно информации о противнике
    public void SetDataAboutEnemy(Enemy EnemySO)
    {
        glossaryEnemyInfo.SetInfoAboutEnemy(EnemySO);
    }

    // Функция загрузки сцены
    public void LoadScene(string sceneName)
    {
        controller.LoadScene(sceneName);
    }
}
