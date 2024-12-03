using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryEnemiesListElementSystem : MonoBehaviour
{
    // ����� �������� ������ �����������, ������� ������������ ����������� ����������

    // ����������
    GlossaryEnemiesListSystem glossaryEnemiesList;

    // ���������� ����������
    [SerializeField] Texture2D backgroundSelected;
    [SerializeField] Texture2D backgroundDeselected;
    [SerializeField] RawImage image_RawImage_Obj;
    [SerializeField] RawImage backgroundImage_RawImage_Obj;
    [SerializeField] TextMeshProUGUI name_TMP_Obj;
    Enemy enemyScriptableObject;

    // ������� �������������
    public void Initialize(GlossaryEnemiesListSystem glossaryEnemiesListLink, Enemy enemySO)
    {
        backgroundImage_RawImage_Obj.texture = backgroundDeselected;

        glossaryEnemiesList = glossaryEnemiesListLink;
        enemyScriptableObject = enemySO;

        image_RawImage_Obj.texture = (Texture)Resources.Load("Sprites\\" + enemyScriptableObject.iconImageName);
        name_TMP_Obj.text = PlayerPrefs.GetString("Language") == "�������" ? enemyScriptableObject.nameRus : enemyScriptableObject.nameEng;
    }

    // ������� ������ ������ �������� ����������
    public void SetSelected()
    {
        backgroundImage_RawImage_Obj.texture = backgroundSelected;
        glossaryEnemiesList.SelectElement(gameObject.GetComponent<GlossaryEnemiesListElementSystem>());
    }

    // ������� �� ���������
    public void SetDeselected()
    {
        backgroundImage_RawImage_Obj.texture = backgroundDeselected;
    }

    // ������� ��� ��������� ���������� � ����������
    public Enemy GetEnemySO()
    {
        return enemyScriptableObject;
    }
}
