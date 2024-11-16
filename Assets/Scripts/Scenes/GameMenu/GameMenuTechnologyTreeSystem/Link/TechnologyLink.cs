using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyLink : MonoBehaviour
{
    // �������� ����������
    GameManager gameManager;

    // ����������
    [SerializeField] TechnologiesLinksSystem technologiesLinksSystem;

    // ����������
    [SerializeField] TechnologyLinkVisualController visualController;
    
    [SerializeField] int status = 0;
    [SerializeField] RectTransform lineImage; // ������� � ����������
    [SerializeField] float lineWidth;
    [SerializeField] List<Technology> techEntityPrevs;
    [SerializeField] List<Technology> techEntityNext;
    [SerializeField] RectTransform pointA; // ������� � ����������
    [SerializeField] RectTransform pointB; // ������� � ����������

    private void Awake()
    {
        gameManager = GameManager.Instance;
        DrawLine(pointA.anchoredPosition, pointB.anchoredPosition);
    }

    // ������� ���������������� �������
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

    // ������� ���������� �������
    public void UpdateStatus()
    {
        foreach (Technology tech in techEntityNext)
        {
            foreach (TechnologyData techData in gameManager.playerGameData.technologies)
            {
                if (tech.ID == techData.ID)
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

    // ������� ��������� ������� Passed
    public void SetPassed()
    {
        visualController.SetPassed();
    }

    // ������� ��������� ������� Opened
    public void SetOpened()
    {
        visualController.SetOpened();
    }

    // ������� ��������� ������� Closed
    public void SetClosed()
    {
        visualController.SetClosed();
    }
}
