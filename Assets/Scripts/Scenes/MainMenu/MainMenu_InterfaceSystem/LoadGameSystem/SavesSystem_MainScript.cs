using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesSystem_MainScript : MonoBehaviour
{
    // ����������:
    [SerializeField] private MainMenuInterfaceSystem_MainScript mainMenuInterfaceSystem_MainScreen;     // ������� ����������.


    // ������� ������ ������:



    // ����������:



    // ���������� ����������:
    [SerializeField] private GameObject Saves_Obj;                                  // ������.
    private List<string> savesNames = new List<string>();                           // ������ ���� ��� ����������.
    [SerializeField] private GameObject saveTemplate;                               // ������ �� ������ ������� ����������.
    [SerializeField] private GameObject content;                                    // ������ �� ������������ ��� ���������� ��������.
    public SaveNode currentSave;                                                    // ��������� ����������.
    [SerializeField] private List<string> techNameList = new List<string>();        // ������ ����������.
    [SerializeField] private List<string> levelNameList = new List<string>();       // ������ �������.

    // ������� �������� ����.
    public void Open()
    {
        Saves_Obj.SetActive(true);
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

        // � ������, ���� � ������ ���������� ������ ���������� ��� - ��������� ������ ������ ��������,
        // ������������ ������� �������������� ����������.
        if (PlayerPrefs.HasKey("savesNames"))
        {
            print(PlayerPrefs.GetString("savesNames"));
            string savesNamesString = PlayerPrefs.GetString("savesNames");

            foreach (string saveName in savesNamesString.Split(new char[] { ' ' }))
            {
                if (saveName != "")
                {
                    savesNames.Add(saveName);

                    // ������ ������� ������.
                    GameObject save = Instantiate(saveTemplate, content.transform.position, content.transform.rotation);

                    // ������������� �������� ������ �� ����������� ������.
                    save.GetComponent<SaveNode>().savesSystem_MainScript = gameObject.GetComponent<SavesSystem_MainScript>();

                    // ������������� ��� ������������ ������.
                    save.transform.SetParent(content.transform, false);

                    // ��������� ���.
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


    // ������� �������� ���������� ����������.
    public void DelSave()
    {
        if (currentSave != null)
        {
            // ��������� ������ ��� ���������� - ������ ������ ������ � ��������� � �������
            // �� ��������� ������ ����������, ��������� ��, ������� �� ������ �������.
            // ����� ��������� ������ ������� ������ ��� �����, � ������� ��� ��� ���������� �����. 
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

            // ������� ������, ��������� � ��������� �����������.
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

    // ������� �������� ����������.
    public void ContinueSave()
    {
        // ���� ���������� ������� - �������� ���, ������������� ���
        // ��� ��������� ��� ���������� � ��������� ����� �������� ����.
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
        // ����� ���������� �� ������.
        else
        {
            print("Continue_BTN: Error - current save is null");
        }
    }
}
