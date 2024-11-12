using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuLevelInfoSystem : MonoBehaviour
{
    [SerializeField] private GameMenuInterfaceSystem interfaceSystem;

    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private RawImage levelImage;
    [SerializeField] private TextMeshProUGUI levelDescription;

    [SerializeField] private GameObject Obj;

    private Level targetLevel;

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

    public void StartLevel()
    {

    }

    public void cameraMovementOff()
    {
        interfaceSystem.cameraMovementOff();
    }

    public void cameraMovementOn()
    {
        interfaceSystem.cameraMovementOn();
    }

}
