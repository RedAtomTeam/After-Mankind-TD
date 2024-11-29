using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryEnemiesListSystem : MonoBehaviour
{
    // Класс управления списком противников

    // Надсистемы
    [SerializeField] GlossaryInterfaceSystem glossaryInterface;

    // Внутренние переменные
    [SerializeField] List<GlossaryEnemiesListElementSystem> glossaryEnemiesListElements;
    [SerializeField] GameObject EnemiesListContent;
    [SerializeField] GameObject EnemiesListElementPrefab;
    Enemy[] allEnemiesEntities;
    [SerializeField] List<Enemy> allEnemiesEntitiesSort;
    GlossaryEnemiesListElementSystem selectedGlossaryEnemiesListElementSystem;

    

    private void Start()
    {
        Initialize();
    }

    // Функция инициализации
    private void Initialize()
    {
        allEnemiesEntities = Resources.LoadAll<Enemy>("");


        
        for (int i = 0; i < allEnemiesEntities.Length; i++)
        {
            for (int j = 0; j < allEnemiesEntities.Length; j++)
            {
                if (allEnemiesEntities[j].ID == i)
                {
                    allEnemiesEntitiesSort.Add(allEnemiesEntities[j]);
                    break;
                }
            }
        }
        
        for (int i = 0; i < allEnemiesEntitiesSort.Count; i++)
        {
            var EnemiesListEl = Instantiate(EnemiesListElementPrefab);
            EnemiesListEl.transform.parent = EnemiesListContent.transform;
            EnemiesListEl.GetComponent<GlossaryEnemiesListElementSystem>().Initialize(gameObject.GetComponent<GlossaryEnemiesListSystem>(), allEnemiesEntitiesSort[i]);
            
            EnemiesListEl.transform.localScale = Vector3.one;
            EnemiesListEl.transform.localPosition = new Vector3(EnemiesListEl.transform.localPosition.x, EnemiesListEl.transform.localPosition.y,  0);

            glossaryEnemiesListElements.Add(EnemiesListEl.GetComponent<GlossaryEnemiesListElementSystem>());
        }
       
        glossaryEnemiesListElements[0].SetSelected();
    }

    // Функция выбора противника
    public void SelectElement(GlossaryEnemiesListElementSystem targetGlossaryEnemiesListElementSystem)
    {
        foreach (var el in glossaryEnemiesListElements)
        {
            if (el.gameObject == targetGlossaryEnemiesListElementSystem.gameObject)
            {
                continue;
            }
            el.SetDeselected();
        }

        selectedGlossaryEnemiesListElementSystem = targetGlossaryEnemiesListElementSystem;
        glossaryInterface.SetDataAboutEnemy(targetGlossaryEnemiesListElementSystem.GetEnemySO());

        MakeButtonSound();
    }

    public void MakeButtonSound()
    {
        glossaryInterface.MakeButtonSound();
    }
}
