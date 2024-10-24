using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 2f;     // Velocidad de zoom
    public float minZoom = 20f;      // Zoom mínimo (más cerca)
    public float maxZoom = 60f;      // Zoom máximo (más lejos)
    public KeyCode zoomKey = KeyCode.Z; // Tecla para hacer zoom
    public Camera[] cameras;         // Arreglo de cámaras

    private Camera activeCamera;

    void Start()
    {
        if (cameras.Length > 0)
        {
            // Asignar la primera cámara como activa por defecto al inicio
            activeCamera = cameras[0];
        }
    }

    void Update()
    {
        // Cambiar la cámara activa si es necesario (por ejemplo, con teclas 1, 2, 3, etc.)
        for (int i = 0; i < cameras.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SetActiveCamera(cameras[i]);
            }
        }

        // Si se presiona la tecla de zoom, ajustamos el campo de visión de la cámara activa
        if (Input.GetKey(zoomKey))
        {
            if (activeCamera != null)
            {
                float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
                activeCamera.fieldOfView = Mathf.Clamp(activeCamera.fieldOfView - zoomAmount, minZoom, maxZoom);
            }
        }
    }

    void SetActiveCamera(Camera newActiveCamera)
    {
        // Desactivar todas las cámaras
        foreach (Camera cam in cameras)
        {
            cam.enabled = false;
        }

        // Activar solo la nueva cámara seleccionada
        newActiveCamera.enabled = true;
        activeCamera = newActiveCamera;
    }
}
