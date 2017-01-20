using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        CheckForGroundCollision();
        MovePlayer();
    } 

    private void MovePlayer()
    {
        if (isGrounded)
        {
            doubleJumped = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.W) && !doubleJumped && !isGrounded)
        {
            Jump();
            doubleJumped = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void Jump()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    private void CheckForGroundCollision()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
