using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : MonoBehaviour {

  [SerializeField]
  private GameObject[] lockingBlocks;
  [SerializeField]
  Sprite PressedButton;

  bool hasBeenPressed = false;

  void OnTriggerEnter2D(Collider2D other) {
    if (!hasBeenPressed && other.tag != "Finish") {
      StartCoroutine("DestroyBlocks");
    }
  } 

  IEnumerator DestroyBlocks() {
    // sets as pressed
    this.gameObject.GetComponent<SpriteRenderer>().sprite = PressedButton;
    hasBeenPressed = true;

    foreach( GameObject block in lockingBlocks) {
      Destroy(block);
      yield return new WaitForSeconds(0.25f);
    }
    yield return null;
  }

}
