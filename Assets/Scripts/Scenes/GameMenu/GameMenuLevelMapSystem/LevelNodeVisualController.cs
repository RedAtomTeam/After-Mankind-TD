using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelNodeVisualController : MonoBehaviour, IPointerClickHandler
{
    // Надсистемы
    [SerializeField] LevelMapNode levelMapNode;

    [SerializeField] RawImage nodeObject;
    [SerializeField] RawImage nodeStroke;

    [SerializeField] Color passedColor;
    [SerializeField] Color openedColor;
    [SerializeField] Color closedColor;

    // Функция установки состояни Passed
    public void SetPassed()
    {
        nodeObject.color = passedColor;
    }

    // Функция установки состояни Opened
    public void SetOpened()
    {
        nodeObject.color = openedColor;
    }

    // Функция установки состояни Closed
    public void SetClosed()
    {
        nodeObject.color = closedColor;
    }

    // Функция обработки кликов
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 buttonLocalPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(nodeObject.rectTransform, Camera.main.WorldToScreenPoint(Input.mousePosition), null, out buttonLocalPoint);

            float wS = (nodeObject.texture.width / nodeObject.GetComponent<RectTransform>().rect.width);
            float hS = (nodeObject.texture.height / nodeObject.GetComponent<RectTransform>().rect.height);


            float diffX = (eventData.pressPosition.x - Camera.main.WorldToScreenPoint(nodeObject.transform.position).x);
            float diffY = (eventData.pressPosition.y - Camera.main.WorldToScreenPoint(nodeObject.transform.position).y);
            print($"DIFFERENT: {diffX}-{diffY}");

            Vector2 sizeInUnits = nodeObject.rectTransform.localScale;

            // Получаем количество пикселей на юнит через orthographicSize
            float pixelsPerUnit = Screen.height / (2f * Camera.main.orthographicSize);

            float widthInPixels = sizeInUnits.x * pixelsPerUnit;
            float heightInPixels = sizeInUnits.y * pixelsPerUnit;

            float percentX = (diffX + (widthInPixels / 2)) / widthInPixels;
            float percentY = (diffY + (heightInPixels / 2)) / heightInPixels;

            print(percentX);
            print(percentY);

            int CorX = (int)(percentX * nodeObject.texture.width);
            int CorY = (int)(percentY * nodeObject.texture.height);

            Color32 col = (nodeObject.texture as Texture2D).GetPixel(CorX, CorY);

            if (col.a > 0)
            {
                levelMapNode.Click();
            }
        }
    }
}
