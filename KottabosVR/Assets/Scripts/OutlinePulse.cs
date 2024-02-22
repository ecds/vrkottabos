using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinePulse : MonoBehaviour
{
    public Outline outline;
    public Color outlineColor;
    int pulseCount;

    public void Start()
    {
        pulseCount = 0; //keeps track of how many times loop has gone on
        outline = this.GetComponent<Outline>(); //the Outline script
        outlineColor = this.GetComponent<Outline>().OutlineColor; //gets the color and opacity of the outline from the Outline script
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float time = 0.0f; //timer starts at zero
        float duration = 0.8f; //fade out lasts 0.8 seconds
        while (time < duration)
        {
            outlineColor.a = Mathf.Lerp(1, 0, time / duration); //changes opacity value over time
            time += Time.deltaTime; 
            outline.OutlineColor = outlineColor; //sets outline color to adjusted opacity value
            yield return null;
        }

        pulseCount++; //marks that a loop has been completed. after 8 loops, outline no longer fades in anymore
        if(pulseCount < 8)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            outlineColor.a = 0;
            outline.OutlineColor = outlineColor; //sets alpha to 0 if loop is over
        }
        
    }

    IEnumerator FadeIn()
    {
        float time = 0.0f;
        float duration = 0.25f; //fade out lasts 0.25 seconds
        while (time < duration)
        {
            outlineColor.a = Mathf.Lerp(0, 1, time / duration);
            time += Time.deltaTime;
            outline.OutlineColor = outlineColor;
            yield return null;
        }
        
        StartCoroutine(FadeOut());
    }
}

