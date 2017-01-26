using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioController))]
public class Rubber : MonoBehaviour, GameBlockMatI
{
    private AudioController audioController;

    private void Awake()
    {
        audioController = GetComponent<AudioController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioController.PlaySoundEffect();
    }

    public void HitObject()
    {
        audioController.PlaySoundEffect();
    }
}
