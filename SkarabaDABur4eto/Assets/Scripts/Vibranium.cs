using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioController))]
public class Vibranium : MonoBehaviour, GameBlockMatI
{
    [SerializeField]
    float jumpHeight;

    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    float groundCheckRadius;
    [SerializeField]
    LayerMask whatIsGround;

    private bool isGrounded;

    private void CheckForGroundCollision()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public void HitObject()
    {
        AudioController audioController = GetComponent<AudioController>();
        audioController.PlaySoundEffect();

        CheckForGroundCollision();

        if (isGrounded)
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
