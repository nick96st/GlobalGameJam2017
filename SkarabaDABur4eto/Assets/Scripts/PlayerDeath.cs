using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;
	[SerializeField]
	Statistic statistic;


	void Start ()
    {
        if(FindObjectOfType<LevelManager>() != null)
            levelManager = FindObjectOfType<LevelManager>();

        if (FindObjectOfType<Statistic>() != null)
            statistic = FindObjectOfType<Statistic>();
	}
	
	void Update ()
    {
		 
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.RespawnPlayer();
			statistic.addDeath();
        }
    }
}
