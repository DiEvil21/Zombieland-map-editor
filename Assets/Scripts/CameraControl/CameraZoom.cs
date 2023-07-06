using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.EventSystems;

public class CameraZoom : MonoBehaviour
{
    public float zoomChange;
    public float smoothChange;
    public float MIN_SIZE, MAX_SIZE;

    private Camera cam;
    // просто приближать удалять камеру, с проверкой не висит ли курсор над UI каким-нибудь
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                cam.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                cam.orthographicSize += zoomChange * Time.deltaTime * smoothChange;
            }

            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, MIN_SIZE, MAX_SIZE);
        }
    }
}

