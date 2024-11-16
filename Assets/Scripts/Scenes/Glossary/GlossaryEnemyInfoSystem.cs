using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryEnemyInfoSystem : MonoBehaviour
{
    // ����������
    [SerializeField] GlossaryEnemyInfoParametrsSystem glossaryEnemyInfoParametrs;

    // ���������� ����������
    [SerializeField] TextMeshProUGUI name_TMP_Obj;
    [SerializeField] TextMeshProUGUI description_TMP_Obj;
    [SerializeField] RawImage image_RawImage_Obj;


    // ������� ��������� ���������� � ���������� � ���� ���������� � ����������
    public void SetInfoAboutEnemy(Enemy EnemySO)
    {
        image_RawImage_Obj.texture = (Texture) Resources.Load(EnemySO.imageName);
        description_TMP_Obj.text = EnemySO.description;
        name_TMP_Obj.text = EnemySO.name;

        glossaryEnemyInfoParametrs.SetEnemiesParametrs(EnemySO);
    }
}
