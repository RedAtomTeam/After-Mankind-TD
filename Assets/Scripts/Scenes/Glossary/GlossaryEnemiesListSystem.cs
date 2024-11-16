using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryEnemiesListSystem : MonoBehaviour
{
    // ����� ���������� ������� �����������

    // ����������
    [SerializeField] GlossaryInterfaceSystem glossaryInterface;

    // ���������� ����������
    [SerializeField] List<GlossaryEnemiesListElementSystem> glossaryEnemiesListElements;
    [SerializeField] GameObject EnemiesListContent;
    [SerializeField] GameObject EnemiesListElementPrefab;
    Enemy[] allEnemiesEntities;
    GlossaryEnemiesListElementSystem selectedGlossaryEnemiesListElementSystem;

    private void Start()
    {
        Initialize();
    }

    // ������� �������������
    private void Initialize()
    {
        allEnemiesEntities = Resources.LoadAll<Enemy>("");
        
        for (int i = 0; i < allEnemiesEntities.Length; i++)
        {
            var EnemiesListEl = Instantiate(EnemiesListElementPrefab);
            EnemiesListEl.transform.parent = EnemiesListContent.transform;
            EnemiesListEl.GetComponent<GlossaryEnemiesListElementSystem>().Initialize(gameObject.GetComponent<GlossaryEnemiesListSystem>(), allEnemiesEntities[i]);
            
            EnemiesListEl.transform.localScale = Vector3.one;
            EnemiesListEl.transform.localPosition = new Vector3(EnemiesListEl.transform.localPosition.x, EnemiesListEl.transform.localPosition.y,  0);

        }
    }

    // ������� ������ ����������
    public void SelectElement(GlossaryEnemiesListElementSystem targetGlossaryEnemiesListElementSystem)
    {
        selectedGlossaryEnemiesListElementSystem = targetGlossaryEnemiesListElementSystem;
        glossaryInterface.SetDataAboutEnemy(targetGlossaryEnemiesListElementSystem.GetEnemySO());
    }
    
}
