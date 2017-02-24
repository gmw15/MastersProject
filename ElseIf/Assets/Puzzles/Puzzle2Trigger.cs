using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Trigger : MonoBehaviour {

    public GameObject puzzle2;
    private bool isShowing = false;

    // Use this for initialization
    void Start()
    {
        puzzle2.SetActive(false);
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
            puzzle2.SetActive(true);
        }
        else
        {
            puzzle2.SetActive(false);
        }
    }

    public void cancelWidget()
    {
        puzzle2.SetActive(false);
    }
}
