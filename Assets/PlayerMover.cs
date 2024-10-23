using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotatonSpeed = 230;

    public Animator animator;

    private float x, y;

    public Rigidbody rb;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;



    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime* rotatonSpeed,0);
        transform.Translate(0, 0, y * Time.deltaTime*runSpeed);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY",y);



        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetKeyDown("space")&&isGrounded)
        {
            animator.Play("Jump");
            Invoke("Jump", 1f);
           
        }


    }
    public void Jump() {

        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

    }

}
