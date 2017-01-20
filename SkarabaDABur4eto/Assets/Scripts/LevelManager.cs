using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckPoint;

    private PlayerController playerController;

    void Start ()
    {
        if (FindObjectOfType<PlayerController>() != null)
            playerController = FindObjectOfType<PlayerController>();
	}

	void Update ()
    {
		
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn!");
        playerController.GetComponent<Transform>().position = currentCheckPoint.GetComponent<Transform>().position;
    }
}
