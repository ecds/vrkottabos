using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class Achievements : MonoBehaviour
{
    //Attached to SceneManager

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!SteamManager.Initialized) { return; }

        if(Input.GetKeyDown(KeyCode.Space)) { return; }

        SteamUserStats.SetAchievement("TEST_ACHIEVEMENT_1");

        SteamUserStats.StoreStats();*/
    }

    public void TestAchievement()
    {
        if (!SteamManager.Initialized) { return; }

        SteamUserStats.SetAchievement("TEST_ACHIEVEMENT_1");

        SteamUserStats.StoreStats();

        Debug.Log("Achievement got");
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
