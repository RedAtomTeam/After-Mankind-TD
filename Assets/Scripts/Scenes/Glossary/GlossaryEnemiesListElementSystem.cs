using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryEnemiesListElementSystem : MonoBehaviour
{
    private GlossaryEnemiesListSystem glossaryEnemiesList;

    [SerializeField] private RawImage image_RawImage_Obj;
    [SerializeField] private TextMeshProUGUI name_TMP_Obj;
    private Enemy enemyScriptableObject;

    public void Initialize(GlossaryEnemiesListSystem glossaryEnemiesListLink, Enemy enemySO)
    {
        glossaryEnemiesList = glossaryEnemiesListLink;
        enemyScriptableObject = enemySO;

        image_RawImage_Obj.texture = (Texture)Resources.Load(enemyScriptableObject.imageName);
        name_TMP_Obj.text = enemyScriptableObject.name;
    }

    public void SetSelected()
    {
        glossaryEnemiesList.SelectElement(gameObject.GetComponent<GlossaryEnemiesListElementSystem>());
    }

    public Enemy GetEnemySO()
    {
        return enemyScriptableObject;
    }
}
