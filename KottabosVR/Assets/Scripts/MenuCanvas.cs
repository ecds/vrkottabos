using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Steamworks;

public class MenuCanvas : MonoBehaviour
{
    GameObject mainMenuCanvas;
    GameObject levelSelectCanvas;
    GameObject settingsCanvas;
    GameObject creditsCanvas;
    GameObject infoCanvas;

    GameObject currentCanvas;

    
    void Start()
    {
        mainMenuCanvas = GameObject.Find("MainMenuCanvas");
        mainMenuCanvas.SetActive(true);
        levelSelectCanvas = GameObject.Find("LevelSelectCanvas");
        levelSelectCanvas.SetActive(false);
        settingsCanvas = GameObject.Find("SettingsCanvas");
        settingsCanvas.SetActive(false);
        creditsCanvas = GameObject.Find("CreditsCanvas");
        creditsCanvas.SetActive(false);
        infoCanvas = GameObject.Find("InfoCanvas");
        infoCanvas.SetActive(false);

        Achievements.Hitrate(Score.hits, Score.misses); //necessary for getting the hitrate achievements if player exits to main menu during a level.
    }


    public void BackToMenu()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void LoadLevelSelectCanvas()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    public void LoadSettingsCanvas()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void LoadCreditsCanvas()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void LoadInfoCanvas()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        infoCanvas.SetActive(true);
    }


}
