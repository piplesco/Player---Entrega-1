using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float runSpeed = 7;   // Velocidad al correr
    public float walkSpeed = 3;  // Velocidad al caminar
    public float rotationSpeed = 230;

    public Animator animator;
    private float x, y;
    private float currentSpeed;  // Velocidad actual

    public Rigidbody rb;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;

    void Start()
    {
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si el personaje está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Movimiento horizontal basado en Input
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Alternar entre caminar y correr dependiendo de si el Shift está presionado
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = walkSpeed;  // Caminar
            animator.speed = 0.5f;     // Ajustar la velocidad de la animación a la mitad para caminar más lento
        }
        else
        {
            currentSpeed = runSpeed;  // Correr
            animator.speed = 1.0f;    // Velocidad normal de la animación al correr
        }

        // Rotar el personaje
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        // Movimiento horizontal con Rigidbody
        Vector3 moveDirection = transform.forward * y * currentSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Actualizar parámetros de animación
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        // Verificar si se ha presionado la tecla de salto y si está en el suelo
        if (Input.GetKeyDown("space") && isGrounded)
        {
            // Iniciar la animación de salto y el salto físico al mismo tiempo
            animator.Play("Jump");
            Jump(); // Ejecutar el salto inmediatamente
        }
    }

    // Función que controla el salto
    public void Jump()
    {
        // Añadir fuerza hacia arriba (salto vertical)
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    // Detectar cuando el personaje toca el suelo
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Restaurar la velocidad de la animación al valor normal
            animator.speed = 1.0f;
        }
    }
}





