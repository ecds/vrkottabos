using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] sounds;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            PlayAudio(0, 6);
        }
        else if (col.gameObject.tag == "Kylix")
        {
            PlayAudio(7, 7);
        }
    }

    public void PlayAudio(int startIndex, int endIndex)
    {
        int index = Random.Range(startIndex, endIndex);
        audioSource.clip = sounds[index];
        audioSource.Play();
    }
}
