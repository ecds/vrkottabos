using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceAudio : MonoBehaviour
{
    float audioTimer, audioDelay, audioRate;
    private AudioSource audioSource;
    public AudioClip[] sounds;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sounds[0];

        audioTimer = 0;
        audioRate = audioSource.clip.length;
        audioDelay = audioSource.clip.length;
    }

    void FixedUpdate()
    {
        audioTimer -= Time.deltaTime;
        if (audioTimer <= 0)
        {
            audioTimer = audioDelay;
            PlayAudio(0, 0, 0.2f);
        }
    }

    public void LoseAudio()
    {
        PlayAudio(1, 1, 0.5f);
    }

    public void WinAudio()
    {
        PlayAudio(2, 2, 0.5f);
    }

    public void PlayAudio(int startIndex, int endIndex, float volume)
    {
        int index = Random.Range(startIndex, endIndex);
        audioSource.clip = sounds[index];
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}
