using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    float horniztonalMove = 0f;

    public float runSpeed = 30f;
    bool jump = false;
    bool crouch = false;

   

    // Update is called once per frame
    void Update()
    {
        horniztonalMove = Input.GetAxisRaw("Horizontal") *runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horniztonalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

       
    }

    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    } 

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horniztonalMove *Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }





}
