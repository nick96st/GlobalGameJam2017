using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var health = other.gameObject.GetComponent<PlayerHealth>();

            if (health != null)
                health.TakeLife();
        }
    }
}
