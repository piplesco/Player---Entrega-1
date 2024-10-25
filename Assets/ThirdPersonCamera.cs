using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;        // Referencia al jugador
    public Vector3 offset = new Vector3(0, 2, -4); // Offset inicial de la c�mara
    public float sensibilidadX = 4f; // Sensibilidad horizontal de la c�mara
    public float sensibilidadY = 2f; // Sensibilidad vertical de la c�mara
    public float minY = -20f;        // L�mite inferior de la rotaci�n vertical
    public float maxY = 60f;         // L�mite superior de la rotaci�n vertical
    public float lerpValue = 0.1f;   // Suavidad del movimiento de seguimiento

    private float rotX;
    private float rotY;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotX = angles.y;
        rotY = angles.x;

        // Bloquea el cursor en el centro de la pantalla y lo oculta
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Obtener entrada del rat�n
        rotX += Input.GetAxis("Mouse X") * sensibilidadX;
        rotY -= Input.GetAxis("Mouse Y") * sensibilidadY;

        // Limitar la rotaci�n vertical
        rotY = Mathf.Clamp(rotY, minY, maxY);

        // Crear la rotaci�n deseada basada en la entrada del rat�n
        Quaternion rotation = Quaternion.Euler(rotY, rotX, 0);

        // Calcular la posici�n de la c�mara aplicando el offset
        Vector3 desiredPosition = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerpValue);

        // Hacer que la c�mara mire hacia el objetivo
        transform.LookAt(target.position + Vector3.up * offset.y);
    }
}

