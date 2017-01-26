using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioController))]
public class EnemyFreakout : MonoBehaviour, GameBlockMatI
{
    [SerializeField]
    Animator enemyAnimator;

    Rigidbody2D body;

    float moveSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        body.velocity = new Vector2(moveSpeed, body.velocity.y);
    }

    public void HitObject()
    {
        AudioController audioController = GetComponent<AudioController>();
        audioController.PlaySoundEffect();

        enemyAnimator.SetBool("isHit", true);
        moveSpeed = 3.0f;

    }
}
