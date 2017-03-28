using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3 : MonoBehaviour {

    //Dropdowns
    List<string> option1 = new List<string>() { "1234572", "qwnch45", "x123fgs" };
    public Dropdown dropdown1;

    List<string> option2 = new List<string>() { "1234572", "qwnch45", "x123fgs" };
    public Dropdown dropdown2;

    List<string> option3 = new List<string>() { "OpenDoor();", "Open Door();", "OpenDoor;" };
    public Dropdown dropdown3;

    List<string> option4 = new List<string>() { "RejectNoAlarm();", "Reject No Alarm;", "RejectNoAlarm;" };
    public Dropdown dropdown4;

    //Text
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    //Submission Button
    public void Submit()
    {
        if (dropdown1.value == 0 && dropdown2.value == 0 && dropdown3.value == 0 && dropdown4.value == 0)
        {
            Debug.Log("Congrats");
            //canvasObject.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong");
        }
        //Check Dropdown 1
        if(dropdown1.value != 0)
        {
            text1.SetActive(true);
        }
        if (dropdown1.value == 0)
        {
            text1.SetActive(false);
        }
        //Check Dropdown 2
        if (dropdown2.value != 0)
        {
            text2.SetActive(true);
        }
        if (dropdown2.value == 0)
        {
            text2.SetActive(false);
        }
        //Check Dropdown 3
        if (dropdown3.value != 0)
        {
            text3.SetActive(true);
        }
        if (dropdown3.value == 0)
        {
            text3.SetActive(false);
        }
        //Check Dropdown 4
        if (dropdown4.value != 0)
        {
            text4.SetActive(true);
        }
        if (dropdown4.value == 0)
        {
            text4.SetActive(false);
        }
    }

    public void Dropdown_IndexChangedDropdown(int index)
    {
        //low
        if (index == 0)
        {
            Debug.Log("option1");
        }

        //medium
        else if (index == 1)
        {
            Debug.Log("option2");
        }

        //high
        else if (index == 2)
        {
            Debug.Log("option3");
        }

        //hanging else
        else
        {
            Debug.Log("Error wth quality");
        }
    }

    // Use this for initialization
    void Start () {
        //As options to dropdowns
        dropdown1.AddOptions(option1);
        dropdown2.AddOptions(option2);
        dropdown3.AddOptions(option3);
        dropdown4.AddOptions(option4);

        //Set text as false
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        //canvasObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
