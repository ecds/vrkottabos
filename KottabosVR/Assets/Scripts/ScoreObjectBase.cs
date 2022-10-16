using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObjectBase : MonoBehaviour
{

    public void addScore(float value)
    {
        Score.score += value;
    }
}
