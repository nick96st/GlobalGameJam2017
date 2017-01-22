using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronWobble : MonoBehaviour,GameBlockMatI {
  private AudioSource source;
  private AudioClip audio;

    LinkedList<GameObject> neighbors;
  [SerializeField]
  bool isHorizontalType;
  [SerializeField]
  float pushPower;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Moveable") {
      neighbors.AddFirst(other.gameObject);
    }
  }

  //void OnCollisionStay2D(Collision2D other) {
  //  Debug.Log("collides");

  //}
  void OnTriggerExit2D(Collider2D other) {
    if(other.gameObject.tag == "Moveable") {
      neighbors.Remove(other.gameObject);
    }
  }


  public void HitObject() {
        source.Stop();
        source.Play();
    foreach( GameObject i in neighbors) {
      Rigidbody2D curRigidBody;
      curRigidBody = i.GetComponent<Rigidbody2D>();
      if( curRigidBody != null) {

        if (isHorizontalType) {
          if (this.gameObject.transform.position.x < i.transform.position.x) {
            curRigidBody.velocity = new Vector2(curRigidBody.velocity.x + pushPower, curRigidBody.velocity.y);
          } else {
            curRigidBody.velocity = new Vector2(curRigidBody.velocity.x - pushPower, curRigidBody.velocity.y);
          }
        }
        else {
          if (this.gameObject.transform.position.y < i.transform.position.y) {
            curRigidBody.velocity = new Vector2(curRigidBody.velocity.x, curRigidBody.velocity.y + pushPower);

          } else {
            curRigidBody.velocity = new Vector2(curRigidBody.velocity.x, curRigidBody.velocity.y - pushPower);
          }
        }
      }
    }

    return;
  }

  // Use this for initialization
  void Start () {
    neighbors = new LinkedList<GameObject>();
    if(!isHorizontalType) {
      this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 1.4f);
    } else {
      this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.4f, 0.6f);
    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
