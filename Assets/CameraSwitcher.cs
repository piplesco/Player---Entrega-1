using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera TPcamera; // C�mara en tercera persona
    public Camera PPcamera; // C�mara en primera persona

    void Start()
    {
        // Al inicio, activamos solo la c�mara en tercera persona
        PPcamera.enabled = false;
    }

    void Update()
    {
        // Cambiar de c�mara al presionar la tecla "C"
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
