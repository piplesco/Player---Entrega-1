using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float runSpeed = 7f;
    public float walkSpeed = 3f;
    public Animator animator;
    public Rigidbody rb;

    private float currentSpeed;
    private Vector3 moveDirection;
    private bool isGrounded;
    private bool isFirstPerson = false; // Nueva variable para alternar entre cámaras

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    void Start()
    {
        rb.isKinematic = false;
    }

    void Update()
    {
        // Cambiar entre primera y tercera persona al presionar la tecla C
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            CameraManager.Instance.SwitchCamera(isFirstPerson); // Activar/desactivar cámaras
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDirection = new Vector3(x, 0, y).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = walkSpeed;
            animator.speed = 0.5f;
        }
        else
        {
            currentSpeed = runSpeed;
            animator.speed = 1.0f;
        }

        if (moveDirection.magnitude >= 0.1f)
        {
            if (!isFirstPerson)
            {
                // Rotación en tercera persona
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0, angle, 0);

                Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                rb.MovePosition(rb.position + moveDir * currentSpeed * Time.deltaTime);
            }
            else
            {
                // Movimiento en primera persona, sin cambiar la rotación
                Vector3 moveDir = transform.right * x + transform.forward * y;
                rb.MovePosition(rb.position + moveDir * currentSpeed * Time.deltaTime);
            }
        }

        // Animaciones de movimiento
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        animator.Play("Jump");
    }
}









