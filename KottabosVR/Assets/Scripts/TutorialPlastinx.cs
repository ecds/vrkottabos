using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlastinx : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] sounds;
    bool onFloor;

    public Tutorial canvas;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Mane")
        {
            PlayAudio(0, 4);
        }
        else if (col.gameObject.layer == 6) //if hits terrain layer
        {
            PlayAudio(5, 9);
            onFloor = true;
        }
        else if (col.gameObject.tag == "Projectile")
        {
            if (!onFloor)
            {

            }
            PlayAudio(10, 14);
        }

    }

    public void PlayAudio(int startIndex, int endIndex)
    {
        int index = Random.Range(startIndex, endIndex);
        audioSource.clip = sounds[index];
        audioSource.Play();
    }

    void Update()
    {
        if(onFloor == true)
        {
            canvas.step3();
            onFloor = false;
        }
    }
}
