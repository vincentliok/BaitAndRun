using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Audio Manager Singleton

public class AudioManagerScript : Singleton<AudioManagerScript>
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    private void PlayMusic()
    {
        // If music is already playing, then don't do anything, otherwise play music

        if (Instance.audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }
}
