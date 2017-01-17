using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz1 : MonoBehaviour {

    public GameObject submitButton;
    //public GameObject answer1TF;
    public Text answer1TF;
    public Text result;

    // Use this for initialization
    void Start () {
        result.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ClickSubmitButtonQuiz1()
    {
        string answer1 = answer1TF.text;

        if (answer1.Length < 8)
        {
            result.text = "Unuckeeeee";
        }
        else
        {
            result.text = "Correct";
        }
    }
}
