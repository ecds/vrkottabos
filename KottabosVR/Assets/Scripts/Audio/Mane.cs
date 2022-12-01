using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mane : MonoBehaviour
{
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Plastinx" || col.gameObject.tag == "Projectile")
        {
            audioSource.Play();
        }
    }
}
