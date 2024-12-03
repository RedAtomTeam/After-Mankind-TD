using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingScreenSystem_TextController : MonoBehaviour
{
    // Класс управления выводом текста во время загрузки.

    [SerializeField] List<string> strings;  // Список советов.
    [SerializeField] TextMeshProUGUI text;  // Ссылка на TextMeshProUGUI для вывода.
    float time;      // Время текст.

    public void SetTime(float setTime)
    {
        time = setTime;
    }


    // Функция запуска работы по выводу текста.
    public void StartTexts()
    {
        System.Random r = new System.Random();
        StartCoroutine(StartTextsCoroutine());
    }

    // Корутина вывода текста.
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
