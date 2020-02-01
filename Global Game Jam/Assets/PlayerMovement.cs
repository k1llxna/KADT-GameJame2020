using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Rigidbody2D playerRB;

    public Animator animator; 

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;
    bool isGrounded;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isjump", true);
        }

        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouch = true;
        //} else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //}
    }

    public void onLanding ()
    {
        animator.SetBool("isjump", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
