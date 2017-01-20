using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TriggerWidget : MonoBehaviour {

    public GameObject menuQuiz2;
    private bool isShowing = false;

    public GameObject trueButton;
    public GameObject falseButton;
    //public GameObject answer1TF;
    public Text questionText;

    // Use this for initialization
    void Start()
    {
        menuQuiz2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //menu.SetActive(isShowing);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "FPSController")
        {
            isShowing = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "FPSController")
        {
            isShowing = false;
        }
    }

    void OnGUI()
    {
        if (isShowing == true)
        {
            menuQuiz2.SetActive(true);
        }
        else
        {
            menuQuiz2.SetActive(false);
        }
    }
}
