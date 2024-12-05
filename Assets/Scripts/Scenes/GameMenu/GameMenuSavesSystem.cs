using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuSavesSystem : MonoBehaviour
{
    GameManager gameManager;

    // ���������� ����������:
    [SerializeField] GameObject Saves_Obj;                                  // ������.
    [SerializeField] GameObject saveTemplate;                               // ������ �� ������ ������� ����������.
    [SerializeField] GameObject content;                                    // ������ �� ������������ ��� ���������� ��������.
    [SerializeField] TMP_InputField inputField;


    // ������� �������� ����.
    public void Open()
    {
        Saves_Obj.SetActive(true);
        UpdateListOfSaves();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        UpdateListOfSaves();
    }

    // ������� �������� ����.
    public void Close()
    {
        Saves_Obj.SetActive(false);
    }

    // ������� ��������� ����������� ���������.
    public void UpdateListOfSaves()
    {
        // ��� ������ ������� �������� ��������� ������.
        while (content.transform.childCount > 0)
        {
            DestroyImmediate(content.transform.GetChild(0).gameObject);
        }

        string saveFilePath = Application.persistentDataPath + "\\" + "saves";

        if (Directory.Exists(saveFilePath))
        {
            var info = new DirectoryInfo(saveFilePath);
            var files = info.GetFiles();
            foreach (var file in files)
            {
                //������ ������� ������.
                GameObject saveEl = Instantiate(saveTemplate, content.transform.position, content.transform.rotation);
                // ������������� �������� ������ �� ����������� ������.
                saveEl.GetComponent<SaveNode>().savesSystem_MainScript = gameObject.GetComponent<SavesSystem_MainScript>();
                // ������������� ��� ������������ ������.
                saveEl.transform.SetParent(content.transform, false);

                GameData gameData;
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(file.FullName, FileMode.Open))
                {
                    gameData = formatter.Deserialize(stream) as GameData;
                }

                string saveDate = $"{gameData.dateAndTimeData.day.ToString()}.{gameData.dateAndTimeData.month.ToString()}.{gameData.dateAndTimeData.year.ToString()}";
                string saveTime = $"{gameData.dateAndTimeData.hours}:{gameData.dateAndTimeData.minutes}:{gameData.dateAndTimeData.seconds}";

                saveEl.GetComponent<SaveNode>().SetDataOnSaveNode(file.Name, saveDate, saveTime);
            }
        }
        else
        {
            print("saveFilePath no exist");
        }
    }

    // ������� ����������, ������� ��������� �� ������
    public void Save()
    {
        bool result = SaveSave();
        if (result)
        {
            print("Save success");
        }
        else
        {
            print("Save error");
        }
    }

    // ������� ����������
    public bool SaveSave()
    {
        string saveFilePath = Application.persistentDataPath + "\\" + "saves";

        string saveFileName = inputField.text;

        if (Directory.Exists(saveFilePath))
        {
            var info = new DirectoryInfo(saveFilePath);
            var files = info.GetFiles();
            foreach (var file in files)
            {
                if (file.Name == saveFileName)
                {
                    return false;
                }
            }

            gameManager.SaveGame(saveFileName);
        }

        UpdateListOfSaves();

        return true;
    }
}
