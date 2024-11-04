using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveSystemDebug : MonoBehaviour
{
    [SerializeField] private Canvas saveSystemDebugCanvas;
    [SerializeField] private GameObject dataPrefab;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;


    [SerializeField] private GameObject balanceObj;
    [SerializeField] private List<GameObject> levelsData;
    [SerializeField] private List<GameObject> technologiesData;

    private GameManager gameManager;

    private int startX = -800, startY = 550;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        GameObject dataObj = Instantiate(dataPrefab, new Vector3(startX, startY, 90), Quaternion.Euler(0, 0, 0));
        dataObj.transform.SetParent(saveSystemDebugCanvas.transform, false);
        dataObj.transform.localScale = new Vector3(1, 1, 1);
        dataObj.GetComponent<TextMeshProUGUI>().text = "Balance: " + gameManager.playerGameData.balanceData.Balance.ToString();
        balanceObj = dataObj;
        startY -= 70;

        for (int i = 0; i < gameManager.playerGameData.levels.Length; i++) 
        {
            dataObj = Instantiate(dataPrefab, new Vector3(startX, startY, 90), Quaternion.Euler(0, 0, 0));
            dataObj.transform.SetParent(saveSystemDebugCanvas.transform, false);
            dataObj.transform.localScale = new Vector3(1, 1, 1);
            levelsData.Add(dataObj);
            dataObj.GetComponent<TextMeshProUGUI>().text = gameManager.playerGameData.levels[i].ID.ToString() + "_Level: " + gameManager.playerGameData.levels[i].status.ToString();
            startY -= 40;
        }

        startX = -400;
        startY = 550;

        for (int i = 0; i < gameManager.playerGameData.technologies.Length; i++)
        {
            dataObj = Instantiate(dataPrefab, new Vector3(startX, startY, 90), Quaternion.Euler(0, 0, 0));
            dataObj.transform.SetParent(saveSystemDebugCanvas.transform, false);
            dataObj.transform.localScale = new Vector3(1, 1, 1);
            dataObj.GetComponent<TextMeshProUGUI>().text = gameManager.playerGameData.technologies[i].ID.ToString() + "_Technology: " + gameManager.playerGameData.technologies[i].status.ToString();
            technologiesData.Add(dataObj);
            startY -= 40;

            if (startY < -400) 
            {
                startY = 550;
                startX += 250;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            saveSystemDebugCanvas.gameObject.SetActive(!saveSystemDebugCanvas.gameObject.active);
        }

        for (int i = 0; i < levelsData.Count; i++)
        {
            int levelID = Convert.ToInt32(levelsData[i].GetComponent<TextMeshProUGUI>().text.ToString().Split("_")[0]);
            //print(levelID);
            int actualLevelStatus = -1;

            for (int j = 0; j < gameManager.playerGameData.levels.Length; j++)
            {
                if (gameManager.playerGameData.levels[j].ID == levelID) 
                {
                    actualLevelStatus = gameManager.playerGameData.levels[j].status;
                    break;
                }
            }
            levelsData[i].GetComponent<TextMeshProUGUI>().text = levelID + "_Level: " + actualLevelStatus.ToString();
        }

        for (int i = 0; i < technologiesData.Count; i++)
        {
            int techID = Convert.ToInt32(technologiesData[i].GetComponent<TextMeshProUGUI>().text.ToString().Split("_")[0]);
            int actualTechStatus = -1;

            for (int j = 0; j < gameManager.playerGameData.technologies.Length; j++)
            {
                if (gameManager.playerGameData.technologies[j].ID == techID)
                {
                    actualTechStatus = gameManager.playerGameData.technologies[j].status;
                    break;
                }
            }
            technologiesData[i].GetComponent<TextMeshProUGUI>().text = techID + "_Tech: " + actualTechStatus.ToString();
        }
    }


    public void RunCommand()
    {
        string fullCommand = inputField.text;
        print("Run Command: " + fullCommand);
        string[] opperands = fullCommand.Split(" ");

        bool done = false;
        if (opperands.Length > 0)
        {
            if (opperands[0] == "SetTechStatus")
            {
                //print("Start Sommant SetTechStatus");
                if (opperands.Length > 2)
                {
                    //print("Operand count test success");
                    for (int i = 0; i < gameManager.playerGameData.technologies.Length; i++)
                    {
                        //print(gameManager.playerGameData.technologies[i].ID.ToString()+"|-|"+opperands[1]);

                        if (gameManager.playerGameData.technologies[i].ID.ToString() == opperands[1])
                        {
                            gameManager.playerGameData.technologies[i].status = Convert.ToInt32(opperands[2]);
                            done = true;
                        }
                    }
                }
            }
            if (opperands[0] == "SetLevelStatus")
            {
                if (opperands.Length > 2)
                {
                    for (int i = 0; i < gameManager.playerGameData.levels.Length; i++)
                    {
                        if (gameManager.playerGameData.levels[i].ID.ToString() == opperands[1])
                        {
                            gameManager.playerGameData.levels[i].status = Convert.ToInt32(opperands[2]);
                            done = true;
                        }
                    }
                }
            }
        }

        if (!done)
        {
            print("Error");
        }
    }

}
