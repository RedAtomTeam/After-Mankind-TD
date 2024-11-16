using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuLevelInfoSystem : MonoBehaviour
{
    // Надсистемы
    [SerializeField] GameMenuInterfaceSystem interfaceSystem;

    // Внутренние переменные
    [SerializeField] TextMeshProUGUI levelName;
    [SerializeField] RawImage levelImage;
    [SerializeField] TextMeshProUGUI levelDescription;
    [SerializeField] GameObject Obj;
    Level targetLevel;

    // Функция открытия информации об уровне
    public void OpenLevelInfo(Level level)
    {
        string language = PlayerPrefs.GetString("Language", "Rus");

        targetLevel = level;

        switch (language)
        {
            case "Rus":
                levelName.text = level.nameRus;
                levelDescription.text = level.descriptionRus;
                break;
            case "Eng":
                levelName.text = level.nameEng;
                levelDescription.text = level.descriptionEng;
                break;
        }

        levelImage.texture = (Texture)Resources.Load(level.imageName);

        cameraMovementOff();

        Obj.SetActive(true);
    }

    // Функция загрузки уровня
    public void StartLevel()
    {

    }

    // Функция выключения камеры
    public void cameraMovementOff()
    {
        interfaceSystem.cameraMovementOff();
    }

    // Функция включения камеры
    public void cameraMovementOn()
    {
        interfaceSystem.cameraMovementOn();
    }

}
