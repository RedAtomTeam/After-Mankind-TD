using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuCameraSystem : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;

    [SerializeField]
    public SpriteRenderer mapRenderer;

    [SerializeField]
    private SpriteRenderer worldMapTabRenderer;

    [SerializeField]
    private SpriteRenderer technologiesTabRenderer;

    private Vector3 startPosition;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    public bool cameraIsOn = true;

    public float defaultCameraSize;
    public float maxCameraSize = 10f;
    public float minCameraSize = 2f;

    public float wheelSense;


    public void ChangeSpriteRenderer()
    {
        if (mapRenderer == worldMapTabRenderer)
        {
            mapRenderer = technologiesTabRenderer;
            //targetCanvas = techTab;
        }
        else
        {
            mapRenderer = worldMapTabRenderer;
            //targetCanvas = levelMapTab;
        }

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
        //print(cam.ScreenToWorldPoint(Input.mousePosition));
        //print(cam.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10)));

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

            //print(Input.GetAxis("Mouse ScrollWheel"));

            //float zoomCoef = targetCanvas.GetComponent<RectTransform>().localScale.x + Input.GetAxis("Mouse ScrollWheel") * 0.1f;
            //if (zoomCoef > maxZoom)
            //{
            //    zoomCoef = maxZoom;
            //}
            //if (zoomCoef < minZoom)
            //{
            //    zoomCoef = minZoom;
            //}
            //zoom = zoomCoef;
            //targetCanvas.GetComponent<RectTransform>().localScale = new Vector3(zoomCoef, zoomCoef, zoomCoef);
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
