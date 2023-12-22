using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScore : ScoreObjectBase
{
    // Should be assigned to the projectile prefab

    public bool hitSomething, hitTerrain, hitTarget;

    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Mane" || col.gameObject.tag == "Plastinx" || col.gameObject.tag == "FloatingCup")
        {
            if(hitTerrain)
            {
                Score.misses -= 1; //retracts a miss if it hit terrain before the target
            }

            if (!hitTarget)
            {
                Score.hits += 1; //adds to hits
            }

            //Debug.Log("HIT " + col.gameObject.tag + " hits: " + Score.hits + " misses: " + Score.misses + " tn: " + hitTerrain + " tg: " + hitTarget);
            hitSomething = true;
            hitTarget = true;
        }

        if (!hitSomething && col.gameObject.layer == 6) //if hits terrain layer
        {
            hitSomething = true;
            hitTerrain = true;
            Score.misses += 1; //adds to misses. ProjectileConroller also contains a line that adds to the misses count in the event that a projectile doesnt hit anything, even terrain
            //Debug.Log("TERRAIN hits: " + Score.hits + " misses: " + Score.misses);
        }
    }

}
