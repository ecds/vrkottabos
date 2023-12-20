using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResetCup : MonoBehaviour
{
    GameObject kylix, button;
    Vector3 startPosition;
    Quaternion startRotation;
    public bool cupIsHeld;

    void Start()
    {
        kylix = GameObject.Find("drinking_cup");
        startPosition = kylix.transform.position;
        startRotation = kylix.transform.rotation;

        button = GameObject.Find("ResetButton");
        button.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(kylix.transform.position, startPosition) > 0.05f && cupIsHeld == false)
        {
            button.SetActive(true);
        }
        else if (Vector3.Distance(kylix.transform.position, startPosition) < 0.05f || cupIsHeld == true)
        {
            button.SetActive(false);
        }
    }

    public void LoadKylix()
    {
        kylix = GameObject.Find("drinking_cup");
        kylix.transform.position = startPosition;
        kylix.transform.rotation = startRotation;
    }

    public void Held()
    {
        if(cupIsHeld == false)
        {
            cupIsHeld = true;
        }
    }

    public void notHeld()
    {
        if (cupIsHeld == true)
        {
            cupIsHeld = false;
        }
    }
}
