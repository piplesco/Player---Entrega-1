using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera TPcamera; // Cámara en tercera persona
    public Camera PPcamera; // Cámara en primera persona

    void Start()
    {
        // Al inicio, activamos solo la cámara en tercera persona
        PPcamera.enabled = false;
    }

    void Update()
    {
        // Cambiar de cámara al presionar la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCameras();
        }
    }

    void ToggleCameras()
    {
        TPcamera.enabled = !TPcamera.enabled;
        PPcamera.enabled = !PPcamera.enabled;
    }
}
