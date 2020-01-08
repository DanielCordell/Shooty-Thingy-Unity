using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;

    private float currentHorizonalMove = 0f;
    private bool currentJump = false;
    private bool isJumpPressed = false;
    public bool currentCrouch = false;

    // Update is called once per frame
    void Update()
    {
        isJumpPressed = Input.GetButton("Jump");
        currentHorizonalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(currentHorizonalMove));
        if (Input.GetButtonDown("Jump"))
            currentJump = true;
        if (Input.GetButtonDown("Crouch"))
            currentCrouch = true;
        if (Input.GetButtonUp("Crouch"))
            currentCrouch = false;
        animator.SetBool("isCrouching", currentCrouch);
    }

    void FixedUpdate()
    {
        controller.Move(currentHorizonalMove * Time.fixedDeltaTime, currentCrouch, currentJump, isJumpPressed);
        currentJump = false;
    }
}
