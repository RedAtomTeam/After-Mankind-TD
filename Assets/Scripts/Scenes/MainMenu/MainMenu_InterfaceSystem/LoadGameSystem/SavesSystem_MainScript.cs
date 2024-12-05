using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavesSystem_MainScript : MonoBehaviour
{
    GameManager gameManager;

    // Надсистемы:
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScreen;     // Система интерфейса.

    // Внутренние переменные:
    [SerializeField] GameObject Saves_Obj;                                  // Объект.
    private List<string> savesNames = new List<string>();                           // Список всех имён сохранений.
    [SerializeField] GameObject saveTemplate;                               // Ссылка на шаблон объекта сохранения.
    [SerializeField] GameObject content;                                    // Ссылка на пространство для размещения шаблонов.
    public SaveNode currentSave;                                                    // Выбранное сохранение.
    [SerializeField] List<string> techNameList = new List<string>();        // Список технологий.
    [SerializeField] List<string> levelNameList = new List<string>();       // Список уровней.

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

        string saveFilePath = Application.persistentDataPath + "\\" + "saves";

        if (Directory.Exists(saveFilePath))
        {
            print("Saves File Search...");

            var info = new DirectoryInfo(saveFilePath);
            var files = info.GetFiles();
            foreach (var file in files)
            {
                print(saveFilePath);
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


    // Функция удаления выбранного сохранения.
    public void DelSave()
    {
        string saveName = Application.persistentDataPath + "\\" + "saves" + "\\" + currentSave.Name;

        if (File.Exists(saveName))
        {
            File.Delete(saveName);
        }

        UpdateListOfSaves();
    }

    // Функция загрузки сохранения.
    public void ContinueSave()
    {
        gameManager.LoadGame(currentSave.Name);
        mainMenuInterfaceSystem_MainScreen.LoadScene("GameMenu");
    }
}
