using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryEnemyInfoSystem : MonoBehaviour
{
    // Подсистемы
    [SerializeField] GlossaryEnemyInfoParametrsSystem glossaryEnemyInfoParametrs;

    // Внутренние переменные
    [SerializeField] TextMeshProUGUI name_TMP_Obj;
    [SerializeField] TextMeshProUGUI description_TMP_Obj;
    [SerializeField] RawImage backgroundImage_RawImage_Obj;


    // Функция установки информации о противнике в окно информации о противнике
    public void SetInfoAboutEnemy(Enemy EnemySO)
    {
        backgroundImage_RawImage_Obj.texture = (Texture) Resources.Load("Sprites\\"+EnemySO.backgroundImageName);
        switch (PlayerPrefs.GetString("Language"))
        {
            case "Русский":
                description_TMP_Obj.text = EnemySO.descriptionRus;
                name_TMP_Obj.text = EnemySO.nameRus;
                break;
            case "English":
                description_TMP_Obj.text = EnemySO.descriptionEng;
                name_TMP_Obj.text = EnemySO.nameEng;
                break;
        }

        glossaryEnemyInfoParametrs.SetEnemiesParametrs(EnemySO);
    }
}
