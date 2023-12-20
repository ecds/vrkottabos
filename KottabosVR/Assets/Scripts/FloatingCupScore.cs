using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCupScore : ScoreObjectBase
{
    // Should be assigned to the floatingcup prefab

    int amountToSink = 3;
    int hits;
    public Transform projectileModel1, projectileModel2, projectileModel3;
    private AudioSource audioSource;
    public AudioClip[] sounds;

    public static int sunkCups;

    void Start()
    {
        sunkCups = 0;

        projectileModel1 = this.gameObject.transform.Find("WineLees");
        projectileModel2 = this.gameObject.transform.Find("WineLees2");
        projectileModel3 = this.gameObject.transform.Find("WineLees3");

        hits = 0;
        projectileModel1.GetComponent<MeshRenderer>().enabled = false;
        projectileModel2.GetComponent<MeshRenderer>().enabled = false;
        projectileModel3.GetComponent<MeshRenderer>().enabled = false;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            

            hits += 1;
            if (hits <= amountToSink)
            {
                PlayAudio(0, 6);

                if (hits == 1)
                {
                    projectileModel1.GetComponent<MeshRenderer>().enabled = true;
                }
                if (hits == 2)
                {
                    projectileModel2.GetComponent<MeshRenderer>().enabled = true;
                }
                if (hits == 3)
                {
                    projectileModel3.GetComponent<MeshRenderer>().enabled = true;
                }
                addScore(3f);
            }
            if(hits == amountToSink)
            {
                Sink();
            }
            Destroy(col.gameObject);
        }

        

    }

    void Sink()
    {
        addScore(7f);
        this.GetComponent<Rigidbody>().mass = 7;
        sunkCups++;
        Debug.Log("sunk cups: " + sunkCups);
    }

    public void PlayAudio(int startIndex, int endIndex)
    {
        int index = Random.Range(startIndex, endIndex);
        audioSource.clip = sounds[index];
        audioSource.Play();
    }
}
