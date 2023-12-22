using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.SceneManagement;

public class Achievements : MonoBehaviour
{
    //Attached to SceneManager

    string currentLevel;

    bool cupsSank, plastinxDown, noMissLvl3;
    static bool hs55, hs65, hs75, hr50, hr75, hr95;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!SteamManager.Initialized) { return; }

        if(Input.GetKeyDown(KeyCode.Space)) { return; }

        SteamUserStats.SetAchievement("TEST_ACHIEVEMENT_1");

        SteamUserStats.StoreStats();*/

        if (currentLevel == "KottabosLevel2" && !cupsSank)
        {
            cupsSankAch();
        }

        if (currentLevel == "KottabosLevel1" && !plastinxDown)
        {
            plastinxAch();
        }

        if (currentLevel == "KottabosLevel3" && !noMissLvl3)
        {
            NoMissLvl3Ach();
        }

    }


    void cupsSankAch()
    {
        if(FloatingCupScore.sunkCups >= 5 && Score.shotsFired <= Score.shots)
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("SINK_ALL_CUPS_IN_LEVEL_2");

            SteamUserStats.StoreStats();

            //Debug.Log("cup achievement got");

            cupsSank = true;
        }
    }

    void plastinxAch()
    {
        if (PlastinxScore.plastinxOnFloor == true && Score.shotsFired == 1) //doesnt get achievement if player knocks it down with one hit, but launches a send projectile before it hits the ground
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("LVL_1_FIRST_TRY");

            SteamUserStats.StoreStats();

            //Debug.Log("plastinx achievement got");

            plastinxDown = true;
        }
    }

    void NoMissLvl3Ach()
    {
        if (Score.misses <= 0 && Score.youWin == true)
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("LVL_3_NO_MISSES");

            SteamUserStats.StoreStats();

            //Debug.Log("no misses achievement got");

            noMissLvl3 = true;
        }
    }

    public static void levelWon(string lvlStat) //called on in the Score script
    {
        int timesWon;
        Steamworks.SteamUserStats.GetStat(lvlStat, out timesWon);

        SteamUserStats.SetStat(lvlStat, timesWon + 1); //adds 1 to steam stat for amount of times this level is won

        int lvl1won, lvl2won, lvl3won, totalwins;
        Steamworks.SteamUserStats.GetStat("lvl1_won", out lvl1won);
        Steamworks.SteamUserStats.GetStat("lvl2_won", out lvl2won);
        Steamworks.SteamUserStats.GetStat("lvl3_won", out lvl3won);

        if (lvl1won <= lvl2won && lvl1won <= lvl3won)
        {
            totalwins = lvl1won; //level 1 has fewest wins
        }
        else if(lvl2won <= lvl1won && lvl2won <= lvl3won)
        {
            totalwins = lvl2won; //level 2 has fewest wins
        }
        else
        {
            totalwins = lvl3won; //level 3 has fewest wins
        }

        SteamUserStats.SetStat("all_lvls_won", totalwins);

        //Debug.Log("Level 1 wins: " + lvl1won + " Level 2 wins: " + lvl2won + " Level 3 wins: " + lvl3won + "Total wins: " + totalwins);

        SteamUserStats.StoreStats();
    }

    public static float GetTime() //called in TimePlayedScript
    {
        float timePlayed;

        if (!SteamManager.Initialized) { return 0.0f; }

        Steamworks.SteamUserStats.GetStat("time_played", out timePlayed); //starts off with last saved amount of time played

        return timePlayed;
    }

    public static void SetTime(float timePlayed) //called in TimePlayed Script
    {
        if (!SteamManager.Initialized) { return; }

        Steamworks.SteamUserStats.SetStat("time_played", timePlayed); //saves time played
    }

    public static void SixteenHours() //called in TimePlayed Script
    {
        if (!SteamManager.Initialized) { return; }

        SteamUserStats.SetAchievement("16_HOURS");

        SteamUserStats.StoreStats();

    }

    public static float GetHighScore(string levelHS) //called in Score script
    {
        float hs;

        if (!SteamManager.Initialized) { return 0.0f; }

        Steamworks.SteamUserStats.GetStat(levelHS, out hs); 

        return hs;
    }

    public static void SetHighScore(string levelHS, float hs) //called in Score script
    {

        if (!SteamManager.Initialized) { return; }

        Steamworks.SteamUserStats.SetStat(levelHS, hs); //saves high score for that level
    }

    public static void HighScoreAchievements(float score) //called in Score script
    {
        if (!hs55 && score >= 55f) 
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("MEDIUM_HIGHSCORE");

            SteamUserStats.StoreStats();

            hs55 = true;
        }

        if (!hs65 && score >= 65f) 
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("HIGH_HIGHSCORE");

            SteamUserStats.StoreStats();

            hs65 = true;
        }

        if (!hs75 && score >= 75f) 
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("HIGHEST_HIGHSCORE");

            SteamUserStats.StoreStats();

            hs75 = true;
        }
    }

    public static void Hitrate(int hits, int misses)
    {
        float hitrate;

        if (!SteamManager.Initialized) { return; }


        if ((hits + misses) > 0)
        {
            SteamUserStats.UpdateAvgRateStat("hit%per100throws", (float)hits, (float)(hits + misses));
        }

        Steamworks.SteamUserStats.GetStat("hit%per100throws", out hitrate);

        if (!hr50 && hitrate >= 0.50f) //couldnt get the achievement to be accomplished automatically through steam api using hit%per100throws like with the levels_won stat, so instead i had to create these if statements
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("MEDIUM_HITRATE");

            hr50 = true;
        }

        if (!hr75 && hitrate >= 0.75f) 
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("HIGH_HITRATE");

            hr75 = true;
        }

        if (!hr95 && hitrate >= 0.95f) 
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("HIGHEST_HITRATE");

            hr95 = true;
        }

        SteamUserStats.StoreStats();

    }

    

}
