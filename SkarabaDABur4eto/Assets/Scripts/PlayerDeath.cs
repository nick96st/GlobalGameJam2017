using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private AudioSource source;
    private AudioClip audio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        source = this.GetComponent<AudioSource>();

        if (other.CompareTag("Player"))
        {
            source.Stop();
            source.Play();

            var health = other.gameObject.GetComponent<PlayerHealth>();

            if (health != null)
                health.TakeLife();
        }
    }
}
