using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// if you want to slower down more gradually INCREASE THE decay rate
/// the more power the higher it gets
/// the speed is controlled by e const .. it actually increase cuz S is lower not V (S =V.t)
/// 1- right
/// 2- mid
/// 3- left
/// </summary>
public class TripleResonance : MonoBehaviour,GameBlockMatI {

  public const float e = 0.1f;
  [SerializeField]
  int resonatePower1;
  [SerializeField]
  [Range(0f,1.5f)]
  float delay1;
  [SerializeField]
  int resonatePower2;
  [SerializeField]
  [Range(0f, 1.5f)]
  float delay2;
  [SerializeField]
  int resonatePower3;
  [SerializeField]
  [Range(0f, 1.5f)]
  float delay3;
  [SerializeField]
  int ticksDecay;
  [SerializeField]
  private GameObject one, two, three; // the three combos which should be parented under the class 



  private int sema = 3;

  public void HitObject() {
    if (sema == 3) {
      sema = 0;
      StartCoroutine("Res", 1);
      StartCoroutine("Res", 2);
      StartCoroutine("Res", 3);
    }
  }

  IEnumerator Res(int id) {

    // inits
    float offset;
    GameObject myResBlock;
    float delay;
    if (id == 1) {
      offset = resonatePower1/6;
      myResBlock = one;
      delay = delay1;
    } else if(id == 2) {
      offset = resonatePower2/6;
      myResBlock = two;
      delay = delay2;
    } else {
      offset = resonatePower3/6;
      myResBlock = three;
      delay = delay3;
    }

    offset += offset + 0.1f;
    Vector3 staticPos = myResBlock.transform.position;
    float staticTransformX = myResBlock.transform.position.y;
    float delta = (offset+1) / (1+delay);
    int ticks = 0;
    Vector3 move = new Vector3(0f, e,0f);
    bool goingUp = true;

    // waits before it gets propagated
    yield return new WaitForSeconds(delay);

    // movements while until it slows
    while (offset > e) {
      // decays over time
      if(ticks == ticksDecay) {
        ticks = 0;
        offset = offset * 9 / 10;

      }

      // up and down movements
      if (goingUp) {
        if (myResBlock.transform.position.y < staticTransformX + offset) {
          myResBlock.transform.Translate(move);
        } else {
          goingUp = false;
        }
      } else {
        if(myResBlock.transform.position.y > staticTransformX - offset) {
          myResBlock.transform.Translate(-move);
        } else {
          goingUp = true;
        }
      }
      ticks++;
      yield return new WaitForFixedUpdate();
    }

    goingUp = (myResBlock.transform.position.y - staticTransformX) < 0;
    while(true) {
      if (goingUp) {
        if (myResBlock.transform.position.y + e < staticTransformX) {
          myResBlock.transform.Translate(move);
          yield return new WaitForFixedUpdate();
        } else {
          myResBlock.transform.position = staticPos;
          break;
        }
      }
      else {
        if (myResBlock.transform.position.y - e > staticTransformX) {
          myResBlock.transform.Translate(-move);
          yield return new WaitForFixedUpdate();
        } else {
          myResBlock.transform.position = staticPos;
          break;
        }
      }
    }
    sema++;

  }


  // Use this for initialization
  void Start () {
		
	}

}
