using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private Animator animator;

    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    //Ground Checking variables (player wont fly)
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosisition;
    public float groundCheckCircle;

    //Hold jump higher variables
    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isJumping;

    // Update is called once per frame
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if(input < 0 )
        {//go left
            spriteRenderer.flipX = true;
        }
        else if( input > 0)
        {//go right
            spriteRenderer.flipX = false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosisition.position, groundCheckCircle, groundLayer);
        if(isGrounded == true && Input.GetButtonDown("Jump"))
        {// jumping (getbuttondown used to not pogojumping)
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                isJumping = true;
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            if(Input.GetButtonUp("Jump"))
            {
                isJumping = false;
            }
        }
        animator.SetBool(name: "isRunning", value: input != 0);
        
    }
    void FixedUpdate() //Update 50/s flat
    {
       playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
    }
}
