using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScore : ScoreObjectBase
{
    // Should be assigned to the projectile prefab

    public bool hitSomething;

    void OnCollisionEnter(Collision col)
    {
        //hitSomething variable starts as false
        //check all possible special tages
        //if no special tags, hitSomething stays false
        //when object is destroyed in ProjectileController, if hitSomething false, add to int "misses" in score

        if(col.gameObject.tag == "Mane" || col.gameObject.tag == "Plastinx" || col.gameObject.tag == "FloatingCup")
        {
            hitSomething = true;
        }
    }

}
