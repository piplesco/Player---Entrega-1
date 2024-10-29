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
        
        if (Instance == null)
            Instance = this;

        
        if (firstPersonCamera == null)
            firstPersonCamera = GameObject.Find("PrimeraPersona");

        if (thirdPersonCamera == null)
            thirdPersonCamera = GameObject.Find("TerceraPersona");
    }

    public void SwitchCamera(bool isFirstPerson)
    {
        
        firstPersonCamera.SetActive(isFirstPerson);
        thirdPersonCamera.SetActive(!isFirstPerson);
    }
}


