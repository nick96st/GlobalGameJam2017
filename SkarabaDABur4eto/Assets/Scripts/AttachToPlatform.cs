using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockBehaviour : MonoBehaviour {
    public Rigidbody2D myrigidbody2D;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity=new Vector2(myrigidbody2D.velocity.x,5); 
        }

	}
    //Dvijenie s platformata kogato e vurhu neq
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.transform.tag == "mPlatform")
        {
            transform.parent = other.transform;
        }
    }
    // Da ne se dviji s platformata kogato sleze ot neq
    void OnCollisionExit2D (Collision2D other)
    {
        if (other.transform.tag == "mPlatform")
        {
            transform.parent = null;
        }
    }
}
