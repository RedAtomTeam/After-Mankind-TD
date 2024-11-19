using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// ����� ������ ����������.
public class SaveNode : MonoBehaviour
{
    // ����� ���������� �� ������ ����������.


    // ����������:
    public SavesSystem_MainScript savesSystem_MainScript;     // ������� �������� ������ ����������.



    // ���������� ����������:
    [SerializeField] TextMeshProUGUI nameTMP;   // ������ �� TextMeshProUGUI ��� �������� ����������.
    public string Name                                  // �������� ��� ��������� �������� ����������.
    {
        get { return nameTMP.text; }
        private set { nameTMP.text = value; }
    }

    [SerializeField] TextMeshProUGUI dateTMP;   // ������ �� TextMeshProUGUI ��� ��������� ���� ����������.
    [SerializeField] TextMeshProUGUI timeTMP;   // ������ �� TextMeshProUGUI ��� ��������� ������� ����������.

    

    // ������� ��������� ������ � ������ ����������.
    public void SetDataOnSaveNode(string name, string date, string time)
    {
        nameTMP.text = name;
        dateTMP.text = date;
        timeTMP.text = time;
    }

    // ������� ��������� ������ ��� ���������.
    public void SetSaveAsCurrent()
    {
        if (savesSystem_MainScript != null)
        {
            savesSystem_MainScript.currentSave = gameObject.GetComponent<SaveNode>();
        }
    }
}
