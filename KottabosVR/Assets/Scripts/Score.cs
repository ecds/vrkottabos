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

    public GameObject highScoreText;

    public GameObject nextLevelButton;
    public GameObject restartLevelButton;

    private GameObject audioSource;
    public AudioClip[] sounds;

    private bool gameOver, youWin;

    public int shots;
    public static int shotsFired;

    int shotsLeft;

    string currentLevel, currentHighScore;

    bool isTutorial;

    GameObject tutorialCanvas;
    GameObject frontCanvas;
    GameObject frontText;
    GameObject frontScoreText;
    GameObject frontNextLevelButton;
    GameObject frontShotsText;



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
                currentHighScore = "MainMenuHighScore";
                break;
            case "KottabosTutorialLevel":
                pointsToWin = 0;
                shots = 0;
                isTutorial = true;
                currentHighScore = "TutorialHighScore";
                break;
            case "KottabosLevel1":
                pointsToWin = 15;
                shots = 15;
                isTutorial = false;
                currentHighScore = "1HighScore";
                break;
            case "KottabosLevel2":
                pointsToWin = 30;
                shots = 50;
                isTutorial = false;
                currentHighScore = "2HighScore";
                break;
            case "KottabosLevel3":
                pointsToWin = 30;
                shots = 50;
                isTutorial = false;
                currentHighScore = "3HighScore";
                break;
        }

        scoreText = GameObject.Find("ScoreText");

        shotsText = GameObject.Find("ShotsText");

        highScoreText = GameObject.Find("HighScoreText");

        nextLevelButton = GameObject.Find("NextLevelButton");
        nextLevelButton.SetActive(false);
        restartLevelButton = GameObject.Find("RestartLevelButton");

        audioSource = GameObject.Find("TavernAudioSource");

        tutorialCanvas = GameObject.Find("TutorialCanvas");
        frontCanvas = GameObject.Find("FrontCanvas");
        frontText = GameObject.Find("FrontText");
        frontText.SetActive(false);
        frontScoreText = GameObject.Find("FrontScoreText");
        frontScoreText.SetActive(false);
        frontNextLevelButton = GameObject.Find("FrontNextLevelButton");
        frontNextLevelButton.SetActive(false);
        frontShotsText = GameObject.Find("FrontShotsText");


        if (currentLevel == "KottabosTutorialLevel")
        {
            shotsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Shots Left: Unlimited";
            frontShotsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Shots Left: Unlimited";
        }
    }

    void Update()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
        
        shotsLeft = shots - shotsFired;
        if(shotsLeft < 0)
        {
            shotsLeft = 0;
        }

        if(currentLevel != "KottabosTutorialLevel")
        {
            shotsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Shots Left: " + shotsLeft.ToString();
            frontShotsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Shots Left: " + shotsLeft.ToString();
        }
        

        if (gameOver == false && shotsLeft <= 0)
        {
            GameOver();
        }

        if(youWin == false && score >= pointsToWin && gameOver == false)
        {
            YouWin();
        }

        CheckHighScore();
    }

    void GameOver()
    {
        gameOver = true;
        restartLevelButton.SetActive(true);
        if (!isTutorial)
        {
            audioSource.GetComponent<AmbienceAudio>().LoseAudio();
            tutorialCanvas.SetActive(false);
            frontText.GetComponent<TMPro.TextMeshProUGUI>().text = "You Lose!";
            frontScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score.ToString();
            frontText.SetActive(true);
            frontScoreText.SetActive(true);
        }
        
    }

    void YouWin()
    {
        youWin = true;
        nextLevelButton.SetActive(true);
        if (!isTutorial)
        {
            audioSource.GetComponent<AmbienceAudio>().WinAudio();
            tutorialCanvas.SetActive(false);
            frontText.GetComponent<TMPro.TextMeshProUGUI>().text = "You Win!";
            frontScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score.ToString();
            frontText.SetActive(true);
            frontScoreText.SetActive(true);
            frontNextLevelButton.SetActive(true);


        }
        
    }

    void CheckHighScore()
    {
        //HIGH SCORE

        if (score > PlayerPrefs.GetFloat(currentHighScore))
        {
            PlayerPrefs.SetFloat(currentHighScore, score);
        }

        highScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "High Score:\n" + PlayerPrefs.GetFloat(currentHighScore).ToString();

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
