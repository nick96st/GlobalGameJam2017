using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioController))]
public class IronWobble : MonoBehaviour, GameBlockMatI
{
    LinkedList<GameObject> neighbors;
    [SerializeField]
    private bool isHorizontalType;
    [SerializeField]
    private float pushPower;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Moveable"))
            neighbors.AddFirst(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Moveable"))
            neighbors.Remove(other.gameObject);
    }

    public void HitObject()
    {
        AudioController audioController = GetComponent<AudioController>();
        audioController.PlaySoundEffect();

        foreach (GameObject i in neighbors)
        {
            Rigidbody2D curRigidBody;
            curRigidBody = i.GetComponent<Rigidbody2D>();

            if(curRigidBody != null)
            {
                if (isHorizontalType)
                {
                    if (GetComponent<Transform>().position.x < i.GetComponent<Transform>().position.x)
                        curRigidBody.velocity = new Vector2(curRigidBody.velocity.x + pushPower, curRigidBody.velocity.y);
                    else
                        curRigidBody.velocity = new Vector2(curRigidBody.velocity.x - pushPower, curRigidBody.velocity.y);
                }
            }
            else
            {
                if (GetComponent<Transform>().position.y < i.GetComponent<Transform>().position.y)
                    curRigidBody.velocity = new Vector2(curRigidBody.velocity.x, curRigidBody.velocity.y + pushPower);
                else
                    curRigidBody.velocity = new Vector2(curRigidBody.velocity.x, curRigidBody.velocity.y - pushPower);
            }
        }
        return;
    }
 

    // Use this for initialization
    void Start ()
    {
        neighbors = new LinkedList<GameObject>();

        if(!isHorizontalType)
            GetComponent<BoxCollider2D>().size = new Vector2(3.0f, 4.0f);
        else
            GetComponent<BoxCollider2D>().size = new Vector2(4.0f, 3.0f);
	}
}
