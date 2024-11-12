using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuCameraSystem : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;

    [SerializeField]
    private SpriteRenderer mapRenderer;

    [SerializeField]
    private SpriteRenderer worldMapTabRenderer;

    [SerializeField]
    private SpriteRenderer technologiesTabRenderer;

    private Vector3 startPosition;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    public bool cameraIsOn = true;

    // При загрузке сцены рассчитываем координаты карты.
    private void Awake()
    {
        startPosition = cam.transform.position;

        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;

        print(mapMinX);
        print(mapMaxX);
        print(mapMinY);
        print(mapMaxY);
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

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
            //print(dragOrigin);
            //print(cam.ScreenToWorldPoint(Input.mousePosition));
            print(difference);
            cam.transform.position = ClampCamera(cam.transform.position + difference);
            //cam.transform.position = cam.transform.position + difference;
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
