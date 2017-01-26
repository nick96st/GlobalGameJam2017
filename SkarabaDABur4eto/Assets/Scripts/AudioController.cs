using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource source;

    [SerializeField]
    bool playOnAwake = false;

    [SerializeField]
    bool loopAudio = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = playOnAwake;
        source.loop = loopAudio;
    }

    public void PlayBackgroundMusic()
    {
        source.PlayOneShot(source.GetComponent<AudioClip>());
    }

    public void PlaySoundEffect()
    {
        source.Stop();
        source.Play();
    }

    public void PlayFromMultipleClips(AudioClip audioClip)
    {
        source.GetComponent<AudioSource>().clip = audioClip;
        source.Stop();
        source.Play();
    }
}