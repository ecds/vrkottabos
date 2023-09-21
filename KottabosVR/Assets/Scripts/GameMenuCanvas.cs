using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMenuCanvas : MonoBehaviour
{
    //GameObject scoreCanvas;
    GameObject gameMenuCanvas;
    GameObject settingsCanvas;
    GameObject frontCanvas;
    GameObject tutorialCanvas;
    GameObject currentCanvas;

    void Start()
    {

        //scoreCanvas = GameObject.Find("ScoreCanvas");
        //scoreCanvas.SetActive(true);
        gameMenuCanvas = GameObject.Find("GameMenuCanvas");
        gameMenuCanvas.SetActive(false);
        settingsCanvas = GameObject.Find("SettingsCanvas");
        settingsCanvas.SetActive(false);
        tutorialCanvas = GameObject.Find("TutorialCanvas");
        frontCanvas = GameObject.Find("FrontCanvas");
    }

    /*public void LoadScoreCanvas()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
    }*/

    public void LoadFrontCanvas()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        frontCanvas.SetActive(true);
        tutorialCanvas.SetActive(true);
    }

    public void LoadGameMenuCanvas()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        tutorialCanvas.SetActive(false);
        gameMenuCanvas.SetActive(true);
    }

    public void LoadSettingsCanvas()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
}
