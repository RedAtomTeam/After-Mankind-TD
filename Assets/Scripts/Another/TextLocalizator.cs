using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLocalisator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textObj;

    [SerializeField] private string textRu;
    [SerializeField] private string textEng;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(PlayerPrefs.GetString("Language"));
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
