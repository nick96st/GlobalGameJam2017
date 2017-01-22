using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFreakout : MonoBehaviour, GameBlockMatI
{
    [SerializeField]
    Animator enemyAnimator;

    Rigidbody2D body;

    float moveSpeed;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        body.velocity = new Vector2(moveSpeed, body.velocity.y);
    }

    public void HitObject()
    {
        var source = this.GetComponent<AudioSource>();
        enemyAnimator.SetBool("isHit", true);
        moveSpeed = 3.0f;
        source.Stop();
        source.Play();
    }
}
