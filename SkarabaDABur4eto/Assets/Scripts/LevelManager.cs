using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckPoint;

    private PlayerController playerController;
    private CameraController cameraController;

    [SerializeField]
    float respawnDelay;

    private float gravityStore;

    GameObject restartUI;

    private void Awake()
    {
        restartUI = GameObject.Find("RestartUI");
    }

    void Start ()
    {
        // Get PlayerController script
        if (FindObjectOfType<PlayerController>() != null)
            playerController = FindObjectOfType<PlayerController>();
        // Get CameraController script
        if (FindObjectOfType<CameraController>() != null)
            cameraController = FindObjectOfType<CameraController>();

        restartUI.SetActive(false);
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

    public void RestartLevel()
    {
        Debug.Log("RESTARTING LEVEL...");
        restartUI.SetActive(false);
        playerController.GetComponent<Transform>().position = currentCheckPoint.GetComponent<Transform>().position;
        playerController.enabled = true;
        playerController.GetComponent<Renderer>().enabled = true;
        cameraController.isFollowing = true;
        // ...
        var life1 = GameObject.Find("Life1").GetComponent<Image>();
        var life2 = GameObject.Find("Life2").GetComponent<Image>();
        var life3 = GameObject.Find("Life3").GetComponent<Image>();
        life1.enabled = life2.enabled = life3.enabled = true;
        var health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        health.Lives.Add(life1);
        health.Lives.Add(life2);
        health.Lives.Add(life3);
    }
}
