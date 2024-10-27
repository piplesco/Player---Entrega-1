using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;

    void Awake()
    {
        // Crear instancia singleton
        if (Instance == null)
            Instance = this;

        // Encuentra las c�maras en la escena si no se asignan manualmente
        if (firstPersonCamera == null)
            firstPersonCamera = GameObject.Find("PrimeraPersona");

        if (thirdPersonCamera == null)
            thirdPersonCamera = GameObject.Find("TerceraPersona");
    }

    public void SwitchCamera(bool isFirstPerson)
    {
        // Activar o desactivar c�maras seg�n la vista seleccionada
        firstPersonCamera.SetActive(isFirstPerson);
        thirdPersonCamera.SetActive(!isFirstPerson);
    }
}


