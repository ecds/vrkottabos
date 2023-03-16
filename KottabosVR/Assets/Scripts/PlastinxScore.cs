using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlastinxScore : ScoreObjectBase
{
    // Should be assigned to the plastinx prefab

    private AudioSource audioSource;
    public AudioClip[] sounds;
    bool onFloor;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Mane")
        {
            addScore(5f);
            PlayAudio(0,4);
        }
        else if (col.gameObject.layer == 6) //if hits terrain layer
        {
            addScore(10f);
            PlayAudio(5,9);
            onFloor = true;
        }
        else if (col.gameObject.tag == "Projectile")
        {
            if (!onFloor)
            {
                addScore(5f);
            }
            PlayAudio(10,14);
        }

    }

    public void PlayAudio(int startIndex, int endIndex)
    {
        int index = Random.Range(startIndex,endIndex);
        audioSource.clip = sounds[index];
        audioSource.Play();
    }
}
