using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCupScore : ScoreObjectBase
{
    // Should be assigned to the floatingcup prefab

    int amountToSink = 3;
    int hits;
    public Transform projectileModel1, projectileModel2, projectileModel3;

    void Start()
    {
        projectileModel1 = this.gameObject.transform.Find("Sphere");
        projectileModel2 = this.gameObject.transform.Find("Sphere2");
        projectileModel3 = this.gameObject.transform.Find("Sphere3");

        hits = 0;
        projectileModel1.GetComponent<MeshRenderer>().enabled = false;
        projectileModel2.GetComponent<MeshRenderer>().enabled = false;
        projectileModel3.GetComponent<MeshRenderer>().enabled = false;

        
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
                if(hits == 1)
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
    }
}
