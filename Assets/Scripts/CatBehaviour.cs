using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Jump Settings")]
    public float minJumpPower = 5f;     // Minimum jump power
    public float maxJumpPower = 15f;   // Maximum jump power
    public float chargeSpeed = 10f;    // How quickly jump power charges

    private bool isGrounded = false;
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    private bool isChargingJump = false;
    private float currentJumpPower;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentJumpPower = minJumpPower;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip the sprite
        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            FlipSprite();
        }

        // Update animator
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void HandleJump()
    {
        // Ground detection
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isJumping", !isGrounded);

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // Start charging jump
                isChargingJump = true;
                currentJumpPower = minJumpPower;

                animator.SetBool("isChargingJump", true);
                Debug.Log("true ini mah");
            }

            if (Input.GetButton("Jump") && isChargingJump)
            {
                // Charge jump power up to the max value
                currentJumpPower += chargeSpeed * Time.deltaTime;
                currentJumpPower = Mathf.Clamp(currentJumpPower, minJumpPower, maxJumpPower);
            }

            if (Input.GetButtonUp("Jump") && isChargingJump)
            {
                // Release jump
                rb.velocity = new Vector2(rb.velocity.x, currentJumpPower);
                isChargingJump = false;
                animator.SetBool("isJumping", true);
                animator.SetBool("isChargingJump", false);
            }
        }
    }

    void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        // Visualize ground check
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }





}
