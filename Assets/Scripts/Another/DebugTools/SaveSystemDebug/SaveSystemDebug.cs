using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveSystemDebug : MonoBehaviour
{   
    [SerializeField] private Canvas saveSystemDebugCanvas;      // Ссылка на канвас
    [SerializeField] private GameObject dataPrefab;             // Ссылка на префаб данных
    [SerializeField] private TMP_InputField inputField;         // Ссылка на поле ввода
    [SerializeField] private Button button;                     // Ссылка на кнопку запуска команды
    [SerializeField] private GameObject balanceObj;             // Ссылка на объект баланса
    [SerializeField] private List<GameObject> levelsData;       // Список объектов данных об уровнях
    [SerializeField] private List<GameObject> technologiesData; // Список объектов данных о тхнологиях

    private GameManager gameManager;    // Ссылка на игровой менеджер

    private int startX = -800, startY = 550;    // Стартовые точки для спавна объектов данных

    // На старте инициализируем ссылку на менеджер и создаём объекты данных неа канфасе для демонстарции данных из менеджера игры
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

    // Каждый кадр обновляем данные на канвасе
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            saveSystemDebugCanvas.gameObject.SetActive(!saveSystemDebugCanvas.gameObject.active);
        }

        for (int i = 0; i < levelsData.Count; i++)
        {
            int levelID = Convert.ToInt32(levelsData[i].GetComponent<TextMeshProUGUI>().text.ToString().Split("_")[0]);
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

    // Функция запуска команды
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
                if (opperands.Length > 2)
                {
                    for (int i = 0; i < gameManager.playerGameData.technologies.Length; i++)
                    {
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
            if (opperands[0] == "SetTechLevel")
            {
                if (opperands.Length > 2)
                {
                    for (int i = 0; i < gameManager.playerGameData.technologies.Length; i++)
                    {
                        if (gameManager.playerGameData.technologies[i].ID.ToString() == opperands[1])
                        {
                            gameManager.playerGameData.technologies[i].level = Convert.ToInt32(opperands[2]);
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
