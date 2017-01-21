using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;

	void Start ()
    {
        if (FindObjectOfType<LevelManager>() != null)
            levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.currentCheckPoint = this.gameObject;
            Debug.Log("Activated Checkpoint: " + this.GetComponent<Transform>().position);
        }
    }
}
