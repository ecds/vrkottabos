using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScore : ScoreObjectBase
{
    // Should be assigned to the projectile prefab

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Plastinx")
        {
            addScore(5f);
        }
        else if(col.gameObject.tag == "Mane")
        {
            addScore(1f);
        }
    }

}
