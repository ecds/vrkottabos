using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mane : ScoreObjectBase
{
    private AudioSource audioSource;
    public AudioClip[] sounds;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            addScore(1f);
            PlayAudio(0, 0);
        }
        else if (col.gameObject.tag == "Kylix")
        {
            PlayAudio(0, 0);
        }
    }

    public void PlayAudio(int startIndex, int endIndex)
    {
        int index = Random.Range(startIndex, endIndex);
        audioSource.clip = sounds[index];
        audioSource.Play();
    }
}
