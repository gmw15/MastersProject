using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPuzzle3 : MonoBehaviour {

    public GameObject puzzle3;
    private bool isShowing = false;

    // Use this for initialization
    void Start()
    {
        puzzle3.SetActive(false);
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
            puzzle3.SetActive(true);
        }
        else
        {
            puzzle3.SetActive(false);
        }
    }

    public void cancelWidget()
    {
        puzzle3.SetActive(false);
    }
}
