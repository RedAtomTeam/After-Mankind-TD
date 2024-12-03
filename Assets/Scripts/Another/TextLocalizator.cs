using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLocalisator : MonoBehaviour
{
    // Ссылка на объект текста, который будет меняться в зависимости от выбранного языка.
    [SerializeField] private TextMeshProUGUI textObj;

    // Русский текст.
    [SerializeField] private string textRu;
    
    // Английский текст.
    [SerializeField] private string textEng;

    private void Start()
    {
        // Если объект не присвоен пользователем, то он будет автоматически найден на объекте.
        if (textObj == null)
        {
            textObj = GetComponent<TextMeshProUGUI>();
        }
    }

    // Функция обновления текста.
    void Update()
    {
        string lang = PlayerPrefs.GetString("Language", "Русский");
        switch (lang)
        {
            case "Русский":
                textObj.text = textRu; 
                break;
            case "English":
                textObj.text = textEng;
                break;
        }
    }
}
