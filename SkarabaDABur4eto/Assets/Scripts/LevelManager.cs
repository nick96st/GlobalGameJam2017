using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckPoint;

    private PlayerController playerController;
    private CameraController cameraController;

    [SerializeField]
    float respawnDelay;

    private float gravityStore;

    void Start ()
    {
        // Get PlayerController script
        if (FindObjectOfType<PlayerController>() != null)
            playerController = FindObjectOfType<PlayerController>();
        // Get CameraController script
        if (FindObjectOfType<CameraController>() != null)
            cameraController = FindObjectOfType<CameraController>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        // Instantiate some particle on death
        playerController.enabled = false;
        playerController.GetComponent<Renderer>().enabled = false;
        cameraController.isFollowing = false;
        // Discard a life
        Debug.Log("Player Respawn!");
        yield return new WaitForSeconds(respawnDelay);
        playerController.GetComponent<Transform>().position = currentCheckPoint.GetComponent<Transform>().position;
        playerController.enabled = true;
        playerController.GetComponent<Renderer>().enabled = true;
        cameraController.isFollowing = true;
        // Instantiate some particle on respawn
    }
}
