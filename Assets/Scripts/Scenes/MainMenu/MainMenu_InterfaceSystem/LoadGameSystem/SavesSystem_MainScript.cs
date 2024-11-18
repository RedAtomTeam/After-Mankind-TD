using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavesSystem_MainScript : MonoBehaviour
{
    GameManager gameManager;

    // ����������:
    [SerializeField] MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScreen;     // ������� ����������.

    // ���������� ����������:
    [SerializeField] GameObject Saves_Obj;                                  // ������.
    private List<string> savesNames = new List<string>();                           // ������ ���� ��� ����������.
    [SerializeField] GameObject saveTemplate;                               // ������ �� ������ ������� ����������.
    [SerializeField] GameObject content;                                    // ������ �� ������������ ��� ���������� ��������.
    public SaveNode currentSave;                                                    // ��������� ����������.
    [SerializeField] List<string> techNameList = new List<string>();        // ������ ����������.
    [SerializeField] List<string> levelNameList = new List<string>();       // ������ �������.

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

        // � ������, ���� � ������ ���������� ������ ���������� ��� - ��������� ������ ������ ��������,
        // ������������ ������� �������������� ����������.
        //if (PlayerPrefs.HasKey("savesNames"))
        //{
        //    print(PlayerPrefs.GetString("savesNames"));
        //    string savesNamesString = PlayerPrefs.GetString("savesNames");

        //    foreach (string saveName in savesNamesString.Split(new char[] { ' ' }))
        //    {
        //        if (saveName != "")
        //        {
        //            savesNames.Add(saveName);

        //            // ������ ������� ������.
        //            GameObject save = Instantiate(saveTemplate, content.transform.position, content.transform.rotation);

        //            // ������������� �������� ������ �� ����������� ������.
        //            save.GetComponent<SaveNode>().savesSystem_MainScript = gameObject.GetComponent<SavesSystem_MainScript>();

        //            // ������������� ��� ������������ ������.
        //            save.transform.SetParent(content.transform, false);

        //            // ��������� ���.
        //            string saveDate = PlayerPrefs.GetString($"{saveName}_date");
        //            string saveTime = PlayerPrefs.GetString($"{saveName}_time");
        //            save.GetComponent<SaveNode>().SetDataOnSaveNode(saveName, saveDate, saveTime);
        //        }
        //    }

        //    content.GetComponent<RectTransform>().rect.Set(
        //        content.GetComponent<RectTransform>().rect.x,
        //        content.GetComponent<RectTransform>().rect.y,
        //        content.GetComponent<RectTransform>().rect.width,
        //        110 * (savesNames.Count < 2 ? 2 : savesNames.Count));
        //}
        //else
        //{
        //    print("Saves list is empty");
        //}

        //content.GetComponent<RectTransform>().sizeDelta = new Vector2(
        //    content.GetComponent<RectTransform>().rect.width,
        //    110 * (savesNames.Count < 2 ? 2 : savesNames.Count));
    }


    // ������� �������� ���������� ����������.
    public void DelSave()
    {
        string saveName = Application.persistentDataPath + "\\" + currentSave.Name;

        if (File.Exists(saveName))
        {
            File.Delete(saveName);
        }

        UpdateListOfSaves();
    }

    // ������� �������� ����������.
    public void ContinueSave()
    {
        gameManager.LoadGame(currentSave.Name);
        mainMenuInterfaceSystem_MainScreen.LoadScene("GameMenu");
    }
}
