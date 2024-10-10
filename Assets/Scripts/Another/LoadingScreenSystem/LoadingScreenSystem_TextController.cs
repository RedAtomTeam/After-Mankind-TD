using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingScreenSystem_TextController : MonoBehaviour
{
    // ����� ���������� ������� ������ �� ����� ��������.

    [SerializeField] private List<string> strings;  // ������ �������.
    [SerializeField] private TextMeshProUGUI text;  // ������ �� TextMeshProUGUI ��� ������.

    public float time;      // ����� �����.


    // ������� ������� ������ �� ������ ������.
    public void StartTexts()
    {
        System.Random r = new System.Random();
        StartCoroutine(StartTextsCoroutine());
    }

    // �������� ������ ������.
    IEnumerator StartTextsCoroutine()
    {
        int targetStringN = Random.Range(0, strings.Count);
        while (true)
        {
            if (targetStringN == strings.Count)
            {
                targetStringN = 0;
            }
            text.text = strings[targetStringN];
            targetStringN++;
            yield return new WaitForSeconds(time);
        }
    }
}
