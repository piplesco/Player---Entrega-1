using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform target; // Referencia al objeto del jugador
    public float sensibilidadX = 2f; // Sensibilidad horizontal
    public float sensibilidadY = 2f; // Sensibilidad vertical
    public float rotacionLimite = 85f; // Límite de rotación vertical

    private float rotX; // Rotación en el eje X
    private float rotY; // Rotación en el eje Y

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla y ocultarlo
        Cursor.lockState = CursorLockMode.Locked;

        // Si la cámara es hija del objeto del jugador, no necesitamos moverla aquí
        // Solo aseguramos que la posición está bien en la vista de escena
    }

    void Update()
    {
        // Obtener la entrada del ratón
        rotY += Input.GetAxis("Mouse X") * sensibilidadX;
        rotX -= Input.GetAxis("Mouse Y") * sensibilidadY;

        // Limitar la rotación vertical
        rotX = Mathf.Clamp(rotX, -rotacionLimite, rotacionLimite);

        // Aplicar la rotación a la cámara
        transform.localRotation = Quaternion.Euler(rotX, rotY, 0);
    }
}
