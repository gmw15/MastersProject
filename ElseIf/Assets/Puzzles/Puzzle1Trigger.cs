using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Trigger : MonoBehaviour {

    public GameObject puzzle1;
    private bool isShowing = false;

    // Use this for initialization
    void Start()
    {
        puzzle1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //menu.SetActive(isShowing);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "ThirdPersonController")
        {
            isShowing = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "ThirdPersonController")
        {
            isShowing = false;
        }
    }

    void OnGUI()
    {
        if (isShowing == true)
        {
            puzzle1.SetActive(true);
        }
        else
        {
            puzzle1.SetActive(false);
        }
    }

    public void cancelWidget()
    {
        puzzle1.SetActive(false);
    }
}
