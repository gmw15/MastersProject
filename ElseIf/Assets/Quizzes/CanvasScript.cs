using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {

public GameObject menu;
private bool isShowing = false;

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

}
