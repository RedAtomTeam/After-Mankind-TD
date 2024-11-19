using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// Класс записи сохранения.
public class SaveNode : MonoBehaviour
{
    // Класс сохранения из спсика сохранений.


    // Надсистемы:
    public SavesSystem_MainScript savesSystem_MainScript;     // Система загрузки списка сохранений.



    // Внутренние переменные:
    [SerializeField] TextMeshProUGUI nameTMP;   // Ссылка на TextMeshProUGUI для названия сохранения.
    public string Name                                  // Свойство для изменения названия сохранения.
    {
        get { return nameTMP.text; }
        private set { nameTMP.text = value; }
    }

    [SerializeField] TextMeshProUGUI dateTMP;   // Ссылка на TextMeshProUGUI для изменения даты сохранения.
    [SerializeField] TextMeshProUGUI timeTMP;   // Ссылка на TextMeshProUGUI для изменения времени сохранения.

    

    // Функция установки данных в запись сохранения.
    public void SetDataOnSaveNode(string name, string date, string time)
    {
        nameTMP.text = name;
        dateTMP.text = date;
        timeTMP.text = time;
    }

    // Функция установки записи как выбранной.
    public void SetSaveAsCurrent()
    {
        if (savesSystem_MainScript != null)
        {
            savesSystem_MainScript.currentSave = gameObject.GetComponent<SaveNode>();
        }
    }
}
