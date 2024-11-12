using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TechnologyNodeVisualController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TechnologyNode techNode;

    [SerializeField] private RawImage nodeObject;

    [SerializeField] private Color passedColor;
    [SerializeField] private Color openedColor;
    [SerializeField] private Color closedColor;

    public void SetLearned()
    {
        nodeObject.color = passedColor;
    }

    public void SetOpened()
    {
        nodeObject.color = openedColor;
    }

    public void SetClosed()
    {
        nodeObject.color = closedColor;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 buttonLocalPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(nodeObject.rectTransform, Camera.main.WorldToScreenPoint(Input.mousePosition), null, out buttonLocalPoint);

            float wS = (nodeObject.texture.width / nodeObject.GetComponent<RectTransform>().rect.width);
            float hS = (nodeObject.texture.height / nodeObject.GetComponent<RectTransform>().rect.height);
            int xPos = (int)(((eventData.pressPosition.x - Camera.main.WorldToScreenPoint(nodeObject.transform.position).x) + (nodeObject.GetComponent<RectTransform>().rect.width / 2)) * wS);
            int yPos = (int)(((eventData.pressPosition.y - Camera.main.WorldToScreenPoint(nodeObject.transform.position).y) + (nodeObject.GetComponent<RectTransform>().rect.height / 2)) * hS);

            Color32 col = (nodeObject.texture as Texture2D).GetPixel(xPos, yPos);

            if (col.a > 0)
            {
                techNode.Click();
            }
        }
    }
}
