using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TechnologyNodeVisualController : MonoBehaviour, IPointerClickHandler
{
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
            RectTransformUtility.ScreenPointToLocalPointInRectangle(nodeStroke.rectTransform, Camera.main.WorldToScreenPoint(Input.mousePosition), null, out buttonLocalPoint);

            float wS = (nodeStroke.texture.width / nodeStroke.GetComponent<RectTransform>().rect.width);
            float hS = (nodeStroke.texture.height / nodeStroke.GetComponent<RectTransform>().rect.height);
            int xPos = (int)(((eventData.pressPosition.x - Camera.main.WorldToScreenPoint(nodeStroke.transform.position).x) + (nodeStroke.GetComponent<RectTransform>().rect.width / 2)) * wS);
            int yPos = (int)(((eventData.pressPosition.y - Camera.main.WorldToScreenPoint(nodeStroke.transform.position).y) + (nodeStroke.GetComponent<RectTransform>().rect.height / 2)) * hS);

            Color32 col = (nodeStroke.texture as Texture2D).GetPixel(xPos, yPos);

            if (col.a > 0)
            {
                techNode.Click();
            }
        }
    }
}
