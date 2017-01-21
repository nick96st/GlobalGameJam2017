using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingGlass : MonoBehaviour,GameBlockMatI {


  bool isHit = false;
  public GameObject ParticleGlassPrefab;
  GameObject ParticleGlass;
  public GameObject Glass;
  //int count;
  //int max = 25;
	// Use this for initialization
	void Start () {
		
	}
	
	//// Update is called once per frame
	//void Update () {
 //       if (Input.GetKeyDown(KeyCode.A))
 //       {
 //           Destroy(Glass);
 //           ParticleGlass = Instantiate(ParticleGlassPrefab);
 //       }
 //       if (Glass==null)
 //       {
 //           if (count == max)
 //           {
 //               Destroy(ParticleGlass);
 //           }
 //           count++;
 //       }
            
 //               }

  IEnumerator GlassBreak() {
    ParticleGlass = Instantiate(ParticleGlassPrefab);
    ParticleGlass.transform.position = Glass.transform.position;
    Destroy(Glass);
    yield return new WaitForSeconds(0.3f);
    Destroy(ParticleGlass);
    }

  public void HitObject() {
    if(!isHit) {
      isHit = true;
      StartCoroutine("GlassBreak");
    }
  }
}
