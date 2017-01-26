using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpHeight;

    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    float groundCheckRadius;
    [SerializeField]
    LayerMask whatIsGround;

    private bool isGrounded;
    private bool doubleJumped;

    private bool isRunning;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Animator playerAnimator;

    bool isDabbing;
    float speed;
    float height;
    
    private Rigidbody2D rigidbody;

    [SerializeField]
    AudioClip jumpAudio;

    private void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckForGroundCollision();
        MovePlayer();
    } 

    private void FixedUpdate()
    {
        if (rigidbody.velocity.y < (-1.3f)*jumpHeight)
        {
            rigidbody.velocity = new Vector2 ( rigidbody.velocity.x,(-1.3f) * jumpHeight);
        }
    }

    private void MovePlayer()
    {
        isDabbing = false;

        if (isGrounded)
        {
            doubleJumped = false;
            height = 0.0f;
            speed = 0.0f;
        }

        if(doubleJumped)
        {
            height = 0.0f;
            speed = 0.0f;
        }

        if (!isRunning)
        {
            speed = 0.0f;
            playerAnimator.SetFloat("Speed", speed);
        }
            
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            height = 1.0f;
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.W) && !doubleJumped && !isGrounded)
        {
            height = 0.0f;
            Jump();
            doubleJumped = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            this.GetComponent<Transform>().localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            speed = 1.0f;            
            isRunning = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            this.GetComponent<Transform>().localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            speed = 1.0f;
            isRunning = true;
        }
        else
        {
            isRunning = false;

            // Reduce Velocity to NOT slide.
            if (this.GetComponent<Rigidbody2D>().velocity.x > 1.0f)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, this.GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (this.GetComponent<Rigidbody2D>().velocity.x < -1.0f)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDabbing = true;
            speed = 0.0f;
        }
        else
        {
            isDabbing = false;
        }

        playerAnimator.SetFloat("Speed", speed);
        playerAnimator.SetFloat("Height", height);
        playerAnimator.SetBool("doubleJump", doubleJumped);
        playerAnimator.SetBool("isDabbing", isDabbing);
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        AudioController audioController = GetComponent<AudioController>();
        audioController.PlayFromMultipleClips(jumpAudio);
    }

    private void CheckForGroundCollision()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "mPlatform")
        {
            transform.parent = other.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "mPlatform")
        {
            transform.parent = null;
        }
    }
}
