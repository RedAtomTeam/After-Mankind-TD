using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyLink : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private TechnologiesLinksSystem technologiesLinksSystem;
    [SerializeField] private int status = 0;
    [SerializeField] private RectTransform lineImage; // ������� � ����������
    [SerializeField] private float lineWidth;
    [SerializeField] private TechnologyLinkVisualController visualController;

    [SerializeField] private List<Technology> techEntityPrevs;
    [SerializeField] private List<Technology> techEntityNext;
    [SerializeField] private RectTransform pointA; // ������� � ����������
    [SerializeField] private RectTransform pointB; // ������� � ����������

    private void Start()
    {
        gameManager = GameManager.Instance;
        DrawLine(pointA.anchoredPosition, pointB.anchoredPosition);
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        lineImage.anchoredPosition = new Vector2((start.x + end.x) / 2, (start.y + end.y) / 2);

        //lineImage.anchoredPosition = start; // ��������� ��������� ������� �����
        Vector2 direction = end - start; // ������� ����� �������� � ��������� �������
        lineImage.sizeDelta = new Vector2(direction.magnitude, lineImage.sizeDelta.y * lineWidth); // ��������� ����� �����

        // ��������� ���� ��������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        lineImage.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void UpdateStatus()
    {
        foreach (Technology tech in techEntityNext)
        {
            int nextID = tech.ID;

            foreach (TechnologyData techData in gameManager.playerGameData.technologies)
            {
                if (tech.ID == nextID)
                {
                    status = (techData.status >= status ? techData.status : status);
                }
            }
        }

        switch (status)
        {
            case 0:
                SetClosed();
                break;
            case 1:
                SetOpened();
                break;
            case 2:
                SetPassed();
                break;
        }
    }
    public void SetPassed()
    {
        visualController.SetPassed();
    }

    public void SetOpened()
    {
        visualController.SetOpened();
    }

    public void SetClosed()
    {
        visualController.SetClosed();
    }
}
