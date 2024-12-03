using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLocalisator : MonoBehaviour
{
    // ������ �� ������ ������, ������� ����� �������� � ����������� �� ���������� �����.
    [SerializeField] private TextMeshProUGUI textObj;

    // ������� �����.
    [SerializeField] private string textRu;
    
    // ���������� �����.
    [SerializeField] private string textEng;

    private void Start()
    {
        // ���� ������ �� �������� �������������, �� �� ����� ������������� ������ �� �������.
        if (textObj == null)
        {
            textObj = GetComponent<TextMeshProUGUI>();
        }
    }

    // ������� ���������� ������.
    void Update()
    {
        string lang = PlayerPrefs.GetString("Language", "�������");
        switch (lang)
        {
            case "�������":
                textObj.text = textRu; 
                break;
            case "English":
                textObj.text = textEng;
                break;
        }
    }
}
