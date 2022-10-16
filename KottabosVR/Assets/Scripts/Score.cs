using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score;

    public GameObject scoreText;

    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("ScoreText");
    }

    void Update()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
    }

    /*give scripts to cup, projectile, and plastinx
    scripts should have a method for what scores they get when the collide with certain objjects
    shpuld add onto the score variable in this script

    projectile
    plastinx
    floor
    manes
    cups

    if projectile hits mane
        1 points
    if projectile hits plastinx
        5 points
    if projectile hits cup
        3 points


    if plastinx hits mane
        5 points

    if plastinx hits floor
        10 points

    cup needs to be hit 3 times to sink
    if cup sinks
        10 points*/
}
