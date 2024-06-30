using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
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
    public float jumpTime;
    public float jumpTimeCounter;
    private bool isJumping;

    //Notification variables
    public GameObject Notify;

    // Update is called once per frame
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Notify.SetActive(false);
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
           isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        animator.SetBool(name: "isRunning", value: input != 0);
    }
    void FixedUpdate() //Update 50/s flat
    {
       playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
    }
    public void NotifyP()
    {
        Notify.SetActive(true);
    }
    public void DeNotifyP()
    {
        Notify.SetActive(false);
    }
}
