using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlastinxScore : ScoreObjectBase
{
    // Should be assigned to the plastinx prefab

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Mane")
        {
            addScore(5f);
        }
        else if (col.gameObject.layer == 6) //if hits terrain layer
        {
            addScore(10f);
        }
    }

}
