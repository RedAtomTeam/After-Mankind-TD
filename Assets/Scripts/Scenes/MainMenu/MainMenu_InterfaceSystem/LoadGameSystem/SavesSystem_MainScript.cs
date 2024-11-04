using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesSystem_MainScript : MonoBehaviour
{
    // Надсистемы:
    [SerializeField] private MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScreen;     // Система интерфейса.


    // Системы одного уровня:



    // Подсистемы:



    // Внутренние переменные:
    [SerializeField] private GameObject Saves_Obj;                                  // Объект.
    private List<string> savesNames = new List<string>();                           // Список всех имён сохранений.
    [SerializeField] private GameObject saveTemplate;                               // Ссылка на шаблон объекта сохранения.
    [SerializeField] private GameObject content;                                    // Ссылка на пространство для размещения шаблонов.
    public SaveNode currentSave;                                                    // Выбранное сохранение.
    [SerializeField] private List<string> techNameList = new List<string>();        // Список технологий.
    [SerializeField] private List<string> levelNameList = new List<string>();       // Список уровней.

    // Функция открытия окна.
    public void Open()
    {
        Saves_Obj.SetActive(true);
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

        // В случае, если в памяти существует список сохранённых имён - заполняем список нужным префабом,
        // устанавливая каждому соответсвующую информацию.
        if (PlayerPrefs.HasKey("savesNames"))
        {
            print(PlayerPrefs.GetString("savesNames"));
            string savesNamesString = PlayerPrefs.GetString("savesNames");

            foreach (string saveName in savesNamesString.Split(new char[] { ' ' }))
            {
                if (saveName != "")
                {
                    savesNames.Add(saveName);

                    // Создаём элемент списка.
                    GameObject save = Instantiate(saveTemplate, content.transform.position, content.transform.rotation);

                    // Устанавливаем элементу ссылки на управляющие кнопки.
                    save.GetComponent<SaveNode>().savesSystem_MainScript = gameObject.GetComponent<SavesSystem_MainScript>();

                    // Устанавливаем ему родительский объект.
                    save.transform.SetParent(content.transform, false);

                    // Заполняем его.
                    string saveDate = PlayerPrefs.GetString($"{saveName}_date");
                    string saveTime = PlayerPrefs.GetString($"{saveName}_time");
                    save.GetComponent<SaveNode>().SetDataOnSaveNode(saveName, saveDate, saveTime);
                }
            }

            content.GetComponent<RectTransform>().rect.Set(
                content.GetComponent<RectTransform>().rect.x,
                content.GetComponent<RectTransform>().rect.y,
                content.GetComponent<RectTransform>().rect.width,
                110 * (savesNames.Count < 2 ? 2 : savesNames.Count));
        }
        else
        {
            print("Saves list is empty");
        }

        content.GetComponent<RectTransform>().sizeDelta = new Vector2(
            content.GetComponent<RectTransform>().rect.width,
            110 * (savesNames.Count < 2 ? 2 : savesNames.Count));
    }


    // Функция удаления выбранного сохранения.
    public void DelSave()
    {
        if (currentSave != null)
        {
            // Обновляем список имён сохранений - создаём пустую строку и заполняем её именами
            // из нынешнего списка сохранений, игнорируя то, которое мы должны удалить.
            // После сохраняем вместо старого списка имён новый, в котором уже нет удаляемого имени. 
            string newSavesNamesString = "";
            string savesNamesString = PlayerPrefs.GetString("savesNames");
            foreach (string saveName in savesNamesString.Split(new char[] { ' ' }))
            {
                if (saveName != currentSave.Name)
                {
                    newSavesNamesString = $"{(newSavesNamesString == "" ? "" : $"{newSavesNamesString} ")}{saveName}";
                }
            }
            PlayerPrefs.SetString("savesNames", newSavesNamesString);

            // Удаляем записи, связанные с удаляемым сохранением.
            PlayerPrefs.DeleteKey($"{currentSave.Name}_techBalance");
            PlayerPrefs.DeleteKey($"{currentSave.Name}_date");
            PlayerPrefs.DeleteKey($"{currentSave.Name}_time");
            PlayerPrefs.DeleteKey($"{currentSave.Name}_openLevels");

            int targetLevel = 1;

            while (PlayerPrefs.HasKey($"{currentSave.Name}_Level{targetLevel}_Status"))
            {
                PlayerPrefs.SetInt($"Level{targetLevel}_Status", PlayerPrefs.GetInt($"{currentSave.Name}_Level{targetLevel}_Status"));
                PlayerPrefs.SetString($"Level{targetLevel}_Time", PlayerPrefs.GetString($"{currentSave.Name}_Level{targetLevel}_Time"));
                PlayerPrefs.SetString($"Level{targetLevel}_Defence", PlayerPrefs.GetString($"{currentSave.Name}_Level{targetLevel}_Defence"));
                targetLevel++;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < (i == 4 ? 8 : 7); j++)
                {
                    PlayerPrefs.DeleteKey($"{currentSave.Name}_tech{i}_{j}");
                }
            }
        }
        else
        {
            print("DelSave_BTN: Error - current save is null");
        }

        UpdateListOfSaves();

    }

    // Функция загрузки сохранения.
    public void ContinueSave()
    {
        // Если сохранение выбрано - получаем имя, устанавливаем его
        // как выбранное имя сохранения и загружаем сцену игрового меню.
        if (currentSave != null)
        {
            string saveName = currentSave.Name;

            foreach (string techName in techNameList)
            {
                PlayerPrefs.SetInt(techName, PlayerPrefs.GetInt($"{saveName}_{techName}"));
            }

            foreach (string levelName in levelNameList)
            {
                PlayerPrefs.SetInt($"{levelName}_Status", PlayerPrefs.GetInt($"{saveName}_{levelName}_Status"));
            }

            PlayerPrefs.SetInt("techBalance", PlayerPrefs.GetInt($"{saveName}_techBalance"));


            mainMenuInterfaceSystem_MainScreen.LoadScene("GameMenu");
        }
        // Иначе уведомляем об ошибке.
        else
        {
            print("Continue_BTN: Error - current save is null");
        }
    }
}
