using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuCameraSystem : MonoBehaviour
{
    
    // Внутренние переменные
    [SerializeField] Camera cam;

    Vector3 dragOrigin;

    [SerializeField] SpriteRenderer mapRenderer;
    [SerializeField] SpriteRenderer worldMapTabRenderer;
    [SerializeField] SpriteRenderer technologiesTabRenderer;

    Vector3 startPosition;

    float mapMinX;
    float mapMaxX;
    float mapMinY;
    float mapMaxY;

    public bool cameraIsOn = true;

    public float defaultCameraSize;
    public float maxCameraSize = 10f;
    public float minCameraSize = 2f;

    public float wheelSense;

    // Функция для переключения между картами для камеры

    public void ChooseSpriteRendererTech()
    {
        mapRenderer = technologiesTabRenderer;

        cam.orthographicSize = defaultCameraSize;

        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

    public void ChooseSpriteRendererMap()
    {
        mapRenderer = worldMapTabRenderer;

        cam.orthographicSize = defaultCameraSize;

        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }
    
    // При загрузке сцены рассчитываем координаты карты.
    private void Awake()
    {
        startPosition = cam.transform.position;

        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

    // Функция переноса камеры в стартовую позицию
    public void SetPositionOnStartPosition()
    {
        cam.transform.position = startPosition;
    }

    // Функция отслеживание состояния мыши вызывается каждый кадр.
    void Update()
    {
        if (cameraIsOn)
        {
            PanCamera();
        }
    }

    // Функция для отслеживания состояния мыши и перемещения камеры.
    void PanCamera()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float cameraSizeCoef = cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * wheelSense;

            if (cameraSizeCoef > maxCameraSize)
            {
                cameraSizeCoef = maxCameraSize;
            }
            if (cameraSizeCoef < minCameraSize)
            {
                cameraSizeCoef = minCameraSize;
            }

            cam.orthographicSize = cameraSizeCoef;


            dragOrigin = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }
    }

    // Функция для рассчёта перемещения камеры.
    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;


        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        print("newX" + newX.ToString());
        print("newY" + newY.ToString());

        return new Vector3(newX, newY, targetPosition.z);
    }

    // Функция установки камеры в начальное положение.
    private void SetCameraToStart()
    {
        cam.transform.position = startPosition;
    }

    // Функция переключения на вкладку карты.
    public void SetTargetRendererWorldMap()
    {
        SetCameraToStart();
        mapRenderer = worldMapTabRenderer;
    }

    // Функция переключения на вкладку технологий.
    public void SetTargetRendererTechnologies()
    {
        SetCameraToStart();
        mapRenderer = technologiesTabRenderer;
    }
}
