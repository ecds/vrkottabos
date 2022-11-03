using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneLoader : MonoBehaviour
{
    public static bool newgame;
    public static int levelsUnlocked = 1;

    public void LoadNextLevel()
    {
        newgame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToStart()
    {
        newgame = false;
        SceneManager.LoadScene("MainMenu");

    }


    public void LoadTutorial()
    {
        //SceneManager.LoadScene("Tutorial");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("KottabosLevel1");
    }
    public void LoadLevel2()
    {
        //SceneManager.LoadScene("KottabosLevel2");
    }
    public void LoadLevel3()
    {
        //SceneManager.LoadScene("KottabosLevel3");
    }
    public void QuitGame()
    {
        newgame = false;
        Application.Quit();
        Debug.Log("Quit");

    }
}
