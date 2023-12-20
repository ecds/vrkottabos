using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class TimePlayed : MonoBehaviour
{
    //attached to SceneManager

    private static string s_TotalPlayTime;

    float elapsedTime;
    bool ach;

    int prevSeconds;


    void Start()
    {
        elapsedTime = Achievements.GetTime();
        
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        s_TotalPlayTime = string.Format("{0}:{1:00}:{2:00}", hours, minutes, seconds);

        if(hours == 16) //if player plays for sixteen hours, they get the achievement
        {
            Achieve();
        }

        if(seconds == prevSeconds + 1)
        {
            Achievements.SetTime(elapsedTime);//Total time played is saved once a second
            //Debug.Log("time: " + s_TotalPlayTime + " total: " + elapsedTime + " steam: " + Achievements.GetTime());
        }

        prevSeconds = seconds;
    }

    void Achieve()
    {
        if (!ach)
        {
            Debug.Log("get 16 hours achievement");
            Achievements.SixteenHours();
            ach = true;
        }
    }


}
