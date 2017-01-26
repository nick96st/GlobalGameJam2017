using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingGlass : MonoBehaviour,GameBlockMatI {


  bool isHit = false;
  public GameObject ParticleGlassPrefab;
  GameObject ParticleGlass;
  public GameObject Glass;
    AudioSource source;
    AudioClip audio;
    //int count;
    //int max = 25;
    // Use this for initialization
    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }
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
        ParticleGlass.transform.localScale = Glass.transform.lossyScale;
    Destroy(Glass);
        source.PlayOneShot(audio);
        yield return new WaitForSeconds(0.3f);
    Destroy(ParticleGlass);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

  public void HitObject() {
    if(!isHit) {
      isHit = true;
      StartCoroutine("GlassBreak");
    }
  }
}
