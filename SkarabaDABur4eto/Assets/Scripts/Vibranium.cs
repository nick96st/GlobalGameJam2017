using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibranium : MonoBehaviour,GameBlockMatI {

  [SerializeField]
  float jumpHeight;

  [SerializeField]
  Transform groundCheck;
  [SerializeField]
  float groundCheckRadius;
  [SerializeField]
  LayerMask whatIsGround;

  private bool isGrounded;

  private void CheckForGroundCollision() {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
  }


  public void HitObject() {
    CheckForGroundCollision();
    if (isGrounded) {
      this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
  }

  // Use this for initialization
  void Start () {
		
	}
	
}
