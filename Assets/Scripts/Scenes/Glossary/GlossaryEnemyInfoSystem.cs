using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryEnemyInfoSystem : MonoBehaviour
{
    [SerializeField] private GlossaryEnemyInfoParametrsSystem glossaryEnemyInfoParametrs;

    [SerializeField] private TextMeshProUGUI name_TMP_Obj;
    [SerializeField] private TextMeshProUGUI description_TMP_Obj;
    [SerializeField] private RawImage image_RawImage_Obj;


    public void SetInfoAboutEnemy(Enemy EnemySO)
    {
        image_RawImage_Obj.texture = (Texture) Resources.Load(EnemySO.imageName);
        description_TMP_Obj.text = EnemySO.description;
        name_TMP_Obj.text = EnemySO.name;

        glossaryEnemyInfoParametrs.SetEnemiesParametrs(EnemySO);
    }
}
