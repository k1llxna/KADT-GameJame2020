using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;

        animator.SetFloat("Speed2", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump2"))
        {
            jump = true;
            animator.SetBool("isjump2", true);
        }

        if (Input.GetButtonDown("Crouch2"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch2"))
        {
            crouch = false;
        }
    }

    public void OmLanding()
    {
        animator.SetBool("isjump2", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
