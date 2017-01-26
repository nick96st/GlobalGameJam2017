using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioController))]
public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioController audioController = GetComponent<AudioController>();
            audioController.PlaySoundEffect();

            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();

            if (health != null)
                health.TakeLife();
        }
    }
}
