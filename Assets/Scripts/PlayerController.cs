using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float normalSpeed;

    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    // private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;

    private void Start()
    {
        // speed = 0f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);

        if (moveInput == 0) 
        {
            anim.SetBool("isLeftRounding", false); // anim.SetBool("isRunning", false);
            anim.SetBool("isRightRounding", false);
        }
        else if (moveInput > 0) 
        {
            anim.SetBool("isRightRounding", true);
            anim.SetBool("isLeftRounding", false); 
            
        }
        else
        {
            anim.SetBool("isLeftRounding", true); 
            anim.SetBool("isRightRounding", false);
        }

        // if (speed == 0f) 
        // {
        //     anim.SetBool("isLeftRounding", false); // anim.SetBool("isRunning", false);
        //     anim.SetBool("isRightRounding", false);
        // }
        // else if (speed > 0f) 
        // {
        //     anim.SetBool("isRightRounding", true);
        //     anim.SetBool("isLeftRounding", false); 
            
        // }
        // else
        // {
        //     anim.SetBool("isLeftRounding", true); 
        //     anim.SetBool("isRightRounding", false);
        // }
    
    }
    public void OnLeftButtonDown()
    {
        if (speed >= 0f)
        {
            speed = -normalSpeed;
        }
    }
    public void OnRightButtonDown()
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }
    public void OnButtonUp()
    {
        speed = 0f;
    }

    public void OnJumpButtonDown()
    {
        if (isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOff");
        }
    }
    private void Update() 
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // wait until "Jumping" operation is over
            
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOff");

        }
        if (isGrounded) anim.SetBool("isJumping", false);
        else anim.SetBool("isJumping", true); 
        
        
    }
}
