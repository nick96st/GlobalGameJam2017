using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerController;
    private CameraController cameraController;

    [SerializeField]
    LevelManager levelManager;
    [SerializeField]
    Statistic statistic;

    public List<Image> Lives;

    int lives;

    private void Start()
    {
        // Get PlayerController script
        if (FindObjectOfType<PlayerController>() != null)
            playerController = FindObjectOfType<PlayerController>();
        // Get CameraController script
        if (FindObjectOfType<CameraController>() != null)
            cameraController = FindObjectOfType<CameraController>();

        if (FindObjectOfType<LevelManager>() != null)
            levelManager = FindObjectOfType<LevelManager>();

        if (FindObjectOfType<Statistic>() != null)
            statistic = FindObjectOfType<Statistic>();
    }

    private void Update()
    {
        lives = Lives.Count;

        if (lives <= 0)
        {
            playerController.enabled = false;
            playerController.GetComponent<Renderer>().enabled = false;
            cameraController.isFollowing = false;
            levelManager.RestartLevel();
        }
    }

    public void TakeLife()
    {
        var life = Lives[lives - 1];
        life.enabled = false;
        Lives.Remove(life);
        statistic.addDeath();

        if (Lives.Count > 0)
            levelManager.RespawnPlayer();
    }
}
