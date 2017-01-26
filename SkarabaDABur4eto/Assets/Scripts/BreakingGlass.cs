using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioController))]
public class BreakingGlass : MonoBehaviour, GameBlockMatI
{
    public GameObject Glass;

    public GameObject ParticleGlassPrefab;
    GameObject ParticleGlass;

    bool isHit = false;

    private IEnumerator GlassBreak()
    {
        ParticleGlass = Instantiate(ParticleGlassPrefab);
        ParticleGlass.GetComponent<Transform>().position = Glass.GetComponent<Transform>().position;
        ParticleGlass.GetComponent<Transform>().localScale = Glass.GetComponent<Transform>().lossyScale;

        // Play breaking glass sound effect
        AudioController audioController = GetComponent<AudioController>();
        audioController.PlaySoundEffect();

        Destroy(Glass.gameObject);
        yield return new WaitForSeconds(0.3f);
        Destroy(ParticleGlass.gameObject);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void HitObject()
    {
        if(!isHit)
        {
            isHit = true;
            StartCoroutine("GlassBreak");
        }
    }
}