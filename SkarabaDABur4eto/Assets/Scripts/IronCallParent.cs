using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronCallParent : MonoBehaviour, GameBlockMatI
{
    public GameObject parent;

    public void HitObject()
    {
        parent.GetComponent<GameBlockMatI>().HitObject();

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
