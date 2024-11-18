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

    // Внутренние переменные:
    [SerializeField] GameObject Saves_Obj;                                  // Объект.
    private List<string> savesNames = new List<string>();                   // Список всех имён сохранений.
    [SerializeField] GameObject saveTemplate;                               // Ссылка на шаблон объекта сохранения.
    [SerializeField] GameObject content;                                    // Ссылка на пространство для размещения шаблонов.
    [SerializeField] TMP_InputField inputField;


    // Функция открытия окна.
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

    // Функция закрытия окна.
    public void Close()
    {
        Saves_Obj.SetActive(false);
    }

    // Функция установки актуального состояния.
    public void UpdateListOfSaves()
    {
        // Для начала очищаем нынешнее состояние списка.
        while (content.transform.childCount > 0)
        {
            DestroyImmediate(content.transform.GetChild(0).gameObject);
        }
        savesNames.Clear();

        string saveFilePath = Application.persistentDataPath;

        if (Directory.Exists(saveFilePath))
        {
            print("Saves File Search...");

            var info = new DirectoryInfo(saveFilePath);
            var files = info.GetFiles();
            foreach (var file in files)
            {
                print(file.Name);

                //Создаём элемент списка.
                GameObject saveEl = Instantiate(saveTemplate, content.transform.position, content.transform.rotation);
                // Устанавливаем элементу ссылки на управляющие кнопки.
                saveEl.GetComponent<SaveNode>().savesSystem_MainScript = gameObject.GetComponent<SavesSystem_MainScript>();
                // Устанавливаем ему родительский объект.
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

    public bool SaveSave()
    {
        string saveFilePath = Application.persistentDataPath;

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
