using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    AudioSource audioSource;

    GameObject kylix, plastinx;

    GameObject tutorialCanvas1;
    GameObject tutorialCanvas2;
    GameObject tutorialCanvas3;
    GameObject tutorialCanvas4;
    GameObject tutorialCanvas5;

    GameObject currentCanvas;

    bool step1complete, step2complete, step3complete, step4complete, step5complete;

    GameObject nextButton2, nextButton3, nextButton4;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        kylix = GameObject.Find("drinking_cup");
        kylix.SetActive(false);

        plastinx = GameObject.Find("Kottabos Stand");
        plastinx.SetActive(false);

        tutorialCanvas1 = GameObject.Find("Screen1");
        tutorialCanvas1.SetActive(true);
        tutorialCanvas2 = GameObject.Find("Screen2");
        tutorialCanvas2.SetActive(false);
        tutorialCanvas3 = GameObject.Find("Screen3");
        tutorialCanvas3.SetActive(false);
        tutorialCanvas4 = GameObject.Find("Screen4");
        tutorialCanvas4.SetActive(false);
        tutorialCanvas5 = GameObject.Find("Screen5");
        tutorialCanvas5.SetActive(false);


    }

    void LoadKylix()
    {
        kylix.SetActive(true);
    }

    void LoadPlastinx()
    {
        plastinx.SetActive(true);
    }

    public void LoadScreen1()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        tutorialCanvas1.SetActive(true);
    }

    public void LoadScreen2()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        tutorialCanvas2.SetActive(true);
        kylix.SetActive(true);
        nextButton2 = GameObject.Find("NextButton2");
        nextButton2.SetActive(false);
        LoadKylix();
    }

    public void LoadScreen3()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        tutorialCanvas3.SetActive(true);
        nextButton3 = GameObject.Find("NextButton3");
        nextButton3.SetActive(false);
        step2complete = false;
    }

    public void LoadScreen4()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        tutorialCanvas4.SetActive(true);
        nextButton4 = GameObject.Find("NextButton4");
        nextButton4.SetActive(false);
        LoadPlastinx();
    }

    public void LoadScreen5()
    {
        currentCanvas = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentCanvas.SetActive(false);
        tutorialCanvas5.SetActive(true);
    }

    void LoadNextButton2()
    {
        nextButton2.SetActive(true);
    }

    void LoadNextButton3()
    {
        nextButton3.SetActive(true);
    }

    void LoadNextButton4()
    {
        nextButton4.SetActive(true);
    }

    public void step1()
    {
        if (!step1complete)
        {
            step1complete = true;
            LoadNextButton2();
            
        }
    }

    public void step2()
    {
        if (!step2complete)
        {
            step2complete = true;
            LoadNextButton3();
        }
    }

    public void step3()
    {
        if (!step3complete)
        {
            step3complete = true;
            LoadNextButton4();
        }
    }
}
