using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_NewGame : MonoBehaviour
{
    [SerializeField] private ButtonsPanelSystem_MainScript buttonsPanelSystem_MainScript;



    [SerializeField] private List<string> techNameList = new List<string>();
    [SerializeField] private List<string> levelNameList = new List<string>();

    public void NewGameStart()
    {
        foreach (string techName in techNameList) 
        {
            PlayerPrefs.SetInt(techName, 0);
        }

        foreach (string levelName in levelNameList)
        {
            PlayerPrefs.SetInt(levelName, 0);
        }
        PlayerPrefs.SetInt(levelNameList[0], 1);

        PlayerPrefs.SetInt("techBalance", 200);

        buttonsPanelSystem_MainScript.LoadScene("GameMenu");
    }

}
