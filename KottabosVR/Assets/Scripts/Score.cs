using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static float score;

    public float pointsToWin;

    public GameObject scoreText;

    public GameObject shotsText;

    public GameObject nextLevelButton;
    public GameObject restartLevelButton;

    private GameObject audioSource;
    public AudioClip[] sounds;

    private bool gameOver, youWin;

    public int shots;
    public static int shotsFired;

    int shotsLeft;

    string currentLevel;

    bool isTutorial;


    void Start()
    {
        score = 0;
        shotsFired = 0;

        currentLevel = SceneManager.GetActiveScene().name;
        switch (currentLevel)
        {
            case "MainMenu":
                pointsToWin = 0;
                shots = 0;
                isTutorial = true;
                break;
            case "KottabosTutorialLevel":
                pointsToWin = 0;
                shots = 0;
                isTutorial = true;
                break;
            case "KottabosLevel1":
                pointsToWin = 15;
                shots = 15;
                isTutorial = false;
                break;
            case "KottabosLevel2":
                pointsToWin = 30;
                shots = 50;
                isTutorial = false;
                break;
            case "KottabosLevel3":
                pointsToWin = 30;
                shots = 50;
                isTutorial = false;
                break;
        }

        scoreText = GameObject.Find("ScoreText");

        shotsText = GameObject.Find("ShotsText");

        nextLevelButton = GameObject.Find("NextLevelButton");
        nextLevelButton.SetActive(false);
        restartLevelButton = GameObject.Find("RestartLevelButton");
        restartLevelButton.SetActive(false);

        audioSource = GameObject.Find("TavernAudioSource");

    }

    void Update()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
        
        shotsLeft = shots - shotsFired;
        if(shotsLeft < 0)
        {
            shotsLeft = 0;
        }
        shotsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Shots Left: " + shotsLeft.ToString();
        
        if (gameOver == false && shotsLeft <= 0)
        {
            GameOver();
        }

        if(youWin == false && score >= pointsToWin && gameOver == false)
        {
            YouWin();
        }
    }

    void GameOver()
    {
        gameOver = true;
        restartLevelButton.SetActive(true);
        if (!isTutorial)
        {
            audioSource.GetComponent<AmbienceAudio>().LoseAudio();
        }
        
    }

    void YouWin()
    {
        youWin = true;
        nextLevelButton.SetActive(true);
        if (!isTutorial)
        {
            audioSource.GetComponent<AmbienceAudio>().WinAudio();
        }
        
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
