using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TechnologyNodeVisualController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Camera cam;

    // Надсистемы
    [SerializeField] TechnologyNode techNode;

    [SerializeField] RawImage nodeImage;
    [SerializeField] RawImage nodeStroke;

    [SerializeField] Color passedColor;
    [SerializeField] Color openedColor;
    [SerializeField] Color closedColor;


    private void Awake()
    {
        if (techNode.technologyEntity.iconName != "")
        {
            nodeStroke.texture = (Texture2D)Resources.Load(techNode.technologyEntity.iconName);
        }
    }

    // Функция изучения
    public void SetLearned()
    {
        nodeStroke.color = passedColor;
    }

    // Функция открытия
    public void SetOpened()
    {
        nodeStroke.color = openedColor;
    }

    // Функция закрытия
    public void SetClosed()
    {
        nodeStroke.color = closedColor;
    }

    // Функция отслеживания нажатия
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 buttonLocalPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(nodeStroke.rectTransform, cam.WorldToScreenPoint(Input.mousePosition), null, out buttonLocalPoint);

            float wS = (nodeImage.texture.width / nodeImage.GetComponent<RectTransform>().rect.width);
            float hS = (nodeImage.texture.height / nodeImage.GetComponent<RectTransform>().rect.height);
            int xPos = (int)(((eventData.pressPosition.x - cam.WorldToScreenPoint(nodeStroke.transform.position).x) + (nodeStroke.GetComponent<RectTransform>().rect.width / 2)) * wS);
            int yPos = (int)(((eventData.pressPosition.y - cam.WorldToScreenPoint(nodeStroke.transform.position).y) + (nodeStroke.GetComponent<RectTransform>().rect.height / 2)) * hS);

            //Color32 col = (nodeStroke.texture as Texture2D).GetPixel(xPos, yPos);

            print("=================");
            print("Press Data:");
            print($"ED: {eventData.pressPosition.x}-{eventData.pressPosition.y}");
            print($"CP: {(cam.WorldToScreenPoint(nodeImage.transform.position).x)}-{cam.WorldToScreenPoint(nodeImage.transform.position).y}");

            float diffX = (eventData.pressPosition.x - cam.WorldToScreenPoint(nodeImage.transform.position).x);
            float diffY = (eventData.pressPosition.y - cam.WorldToScreenPoint(nodeImage.transform.position).y);
            print($"DIFFERENT: {diffX}-{diffY}");




            Vector2 sizeInUnits = nodeImage.rectTransform.localScale;

            // Получаем количество пикселей на юнит через orthographicSize
            float pixelsPerUnit = Screen.height / (2f * Camera.main.orthographicSize);

            float widthInPixels = sizeInUnits.x * pixelsPerUnit;
            float heightInPixels = sizeInUnits.y * pixelsPerUnit;

            float percentX = (diffX + (widthInPixels / 2)) / widthInPixels;
            float percentY = (diffY + (heightInPixels / 2)) / heightInPixels;


            int CorX = (int)(percentX * nodeImage.texture.width);
            int CorY = (int)(percentY * nodeImage.texture.height);

            Color32 col = (nodeImage.texture as Texture2D).GetPixel(CorX, CorY);



            //print($"ED: {(cam.WorldToScreenPoint(nodeStroke.transform.position).x)}-{cam.WorldToScreenPoint(nodeStroke.transform.position).y}");


            //print($"({nodeImage.texture.width}|{nodeImage.texture.height})X:{CorX}; Y:{CorY}; A:{col.a}");


            if (col.a > 0)
            {
                techNode.Click();
            }
        }
    }
}
