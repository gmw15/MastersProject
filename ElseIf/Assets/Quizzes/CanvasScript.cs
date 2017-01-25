using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasScript : MonoBehaviour {

    //MAKE GUI APPEAR
    public GameObject menu;
    private bool isShowing = false;

    public GameObject submitButton;
    //public GameObject answer1TF;
    public Text answer1TF;
    public Text result;
    // Use this for initialization
    void Start () {
		menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//menu.SetActive(isShowing);
	}


	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "FPSController"){
			isShowing=true;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.name == "FPSController"){
			isShowing=false;
		}
	}

	void OnGUI(){
		if(isShowing==true){
			menu.SetActive(true);
        }
		else{
			menu.SetActive(false);
		}
	}

    //GUI QUIZ
    public void ClickSubmitButtonQuiz1()
    {
        string answer1 = answer1TF.text;
        if (answer1.Length < 8)
        {
            result.text = "Text needs to be long";
        }
        else
        {
            result.text = "Perfect";
        }
    }

}
