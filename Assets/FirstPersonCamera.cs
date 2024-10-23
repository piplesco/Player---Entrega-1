using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform target; // Referencia al objeto del jugador
    public float sensibilidadX = 2f; // Sensibilidad horizontal
    public float sensibilidadY = 2f; // Sensibilidad vertical
    public float rotacionLimite = 85f; // L�mite de rotaci�n vertical

    private float rotX; // Rotaci�n en el eje X
    private float rotY; // Rotaci�n en el eje Y

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla y ocultarlo
        Cursor.lockState = CursorLockMode.Locked;

        // Si la c�mara es hija del objeto del jugador, no necesitamos moverla aqu�
        // Solo aseguramos que la posici�n est� bien en la vista de escena
    }

    void Update()
    {
        // Obtener la entrada del rat�n
        rotY += Input.GetAxis("Mouse X") * sensibilidadX;
        rotX -= Input.GetAxis("Mouse Y") * sensibilidadY;

        // Limitar la rotaci�n vertical
        rotX = Mathf.Clamp(rotX, -rotacionLimite, rotacionLimite);

        // Aplicar la rotaci�n a la c�mara
        transform.localRotation = Quaternion.Euler(rotX, rotY, 0);
    }
}
