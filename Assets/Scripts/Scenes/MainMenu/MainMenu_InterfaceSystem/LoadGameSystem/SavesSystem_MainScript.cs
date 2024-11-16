using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesSystem_MainScript : MonoBehaviour
{
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
        
    }

    // Функция загрузки сохранения.
    public void ContinueSave()
    {
        
    }
}
