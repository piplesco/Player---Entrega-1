using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform playerBody;
    public float sensibilidadX = 2f;
    public float sensibilidadY = 2f;
    public float rotacionLimite = 85f;

    private float rotX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadX;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadY;

        playerBody.Rotate(Vector3.up * mouseX);

        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -rotacionLimite, rotacionLimite);

        transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);
    }
}


