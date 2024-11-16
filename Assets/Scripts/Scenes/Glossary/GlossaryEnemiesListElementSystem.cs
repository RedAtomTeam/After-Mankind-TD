using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryEnemiesListElementSystem : MonoBehaviour
{
    // Класс элемента списка противников, который представляет конкретного противника

    // Надсистемы
    GlossaryEnemiesListSystem glossaryEnemiesList;

    // Внутренние переменные
    [SerializeField] RawImage image_RawImage_Obj;
    [SerializeField] TextMeshProUGUI name_TMP_Obj;
    Enemy enemyScriptableObject;

    // Функция инициализации
    public void Initialize(GlossaryEnemiesListSystem glossaryEnemiesListLink, Enemy enemySO)
    {
        glossaryEnemiesList = glossaryEnemiesListLink;
        enemyScriptableObject = enemySO;

        image_RawImage_Obj.texture = (Texture)Resources.Load(enemyScriptableObject.imageName);
        name_TMP_Obj.text = enemyScriptableObject.name;
    }

    // Функция выбора данной карточки противника
    public void SetSelected()
    {
        glossaryEnemiesList.SelectElement(gameObject.GetComponent<GlossaryEnemiesListElementSystem>());
    }

    // Функция для получения информации о противнике
    public Enemy GetEnemySO()
    {
        return enemyScriptableObject;
    }
}
