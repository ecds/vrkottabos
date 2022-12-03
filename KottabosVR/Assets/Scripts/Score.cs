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

    private bool gameOver, youWin;

    public int shots;
    public static int shotsFired;

    int shotsLeft;

    string currentLevel;


    void Start()
    {
        score = 0;
        shotsFired = 0;

        currentLevel = SceneManager.GetActiveScene().name;
        switch (currentLevel)
        {
            case "MainMenu":
                pointsToWin = 0;
                shots = 999;
                break;
            case "KottabosTutorial":
                pointsToWin = 0;
                shots = 999;
                break;
            case "KottabosLevel1":
                pointsToWin = 15;
                shots = 15;
                break;
            case "KottabosLevel2":
                pointsToWin = 30;
                shots = 50;
                break;
            case "KottabosLevel3":
                pointsToWin = 30;
                shots = 50;
                break;
        }

        scoreText = GameObject.Find("ScoreText");

        shotsText = GameObject.Find("ShotsText");

        nextLevelButton = GameObject.Find("NextLevelButton");
        nextLevelButton.SetActive(false);
        restartLevelButton = GameObject.Find("RestartLevelButton");
        restartLevelButton.SetActive(false);

    }

    void Update()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
        
        shotsLeft = shots - shotsFired;
        shotsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Shots Left: " + shotsLeft.ToString();
        
        if (gameOver == false && shotsLeft <= 0)
        {
            GameOver();
        }

        if(youWin == false && score >= pointsToWin)
        {
            YouWin();
        }
    }

    void GameOver()
    {
        gameOver = true;
        restartLevelButton.SetActive(true);
    }

    void YouWin()
    {
        youWin = true;
        nextLevelButton.SetActive(true);
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
