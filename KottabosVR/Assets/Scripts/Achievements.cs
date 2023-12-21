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
    static bool hs35, hs45, hs55;

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

            Debug.Log("cup achievement got");

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

            Debug.Log("plastinx achievement got");

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

            Debug.Log("no misses achievement got");

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

        Debug.Log("Level 1 wins: " + lvl1won + " Level 2 wins: " + lvl2won + " Level 3 wins: " + lvl3won + "Total wins: " + totalwins);

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
        if(!hs35 && score >= 55f) //change to 55
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.ClearAchievement("MEDIUM_HIGHSCORE");

            SteamUserStats.StoreStats();
        }

        if (!hs45 && score >= 65f) //change to 65
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("HIGH_HIGHSCORE");

            SteamUserStats.StoreStats();
        }

        if (!hs55 && score >= 75f) //change to 75
        {
            if (!SteamManager.Initialized) { return; }

            SteamUserStats.SetAchievement("HIGHEST_HIGHSCORE");

            SteamUserStats.StoreStats();
        }
    }


    /*
    //[Button]
    public void IsThisAchievementUnlocked(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);

        Debug.Log($"Achievement {id} status: " + ach.State);
    }

    //[Button]
    public void UnlockAchievement(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        ach.Trigger();

        Debug.Log($"Achievement {id} unlocked");
    }

    //[Button]
    public void ClearAchievementStatus(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        ach.Trigger();

        Debug.Log($"Achievement {id} cleared");
    }
    */


}
