using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class User{

	public bool success;
	public string error;
	public string email;
	//add username

}


public class AuthenticationScript : MonoBehaviour {

	public string urlLogin = "http://localhost:/action_login.php";
	public string urlRegister = "http://localhost:/action_register.php";

	public GameObject buttonSwapRegistation;
	public GameObject buttonRegister;
	public GameObject mainMenu;
	public GameObject buttonStartGame;

	public GameObject fieldEmailAddress;
	public GameObject fieldPassword;
	public GameObject fieldConfirmPassword;

	public Text textEmail;
	public Text textPassword;
	public Text textConfirmPassword;
	public Text textSwapButton;
	public Text textFeedback;

	WWWForm form;

	public bool showRegistration = false;

	// Use this for initialization
	void Start () {
		displayLoginPanel();
		textFeedback.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void displayLoginPanel(){
		buttonRegister.SetActive(false);
		fieldConfirmPassword.SetActive(false);
	}
	public void SwapSignupSignin(){
		if(showRegistration){
			showRegistration = false;
			buttonStartGame.SetActive(true);
			buttonRegister.SetActive(false);
			fieldConfirmPassword.SetActive(false);
			textSwapButton.text = "Register";
		}
		else{
			showRegistration = true;
			buttonStartGame.SetActive(false);
			buttonRegister.SetActive(true);
			fieldConfirmPassword.SetActive(true);
			textSwapButton.text = "Sign in";
		}
	}

	public void RegisterButtonTapped(){
		textFeedback.text = "Processing Registration..";
		StartCoroutine("RequestUserRegistration");		
	}

	public void LoginButtonTapped(){
		textFeedback.text = "Logging In..";
		StartCoroutine("RequestLogin");
	}

	public IEnumerator RequestLogin(){
		//string email = textEmail.text;
		//string password = textPassword.text;
		string email = textEmail.text;
		string password = textPassword.text;

		form = new WWWForm();
		form.AddField("email", email);
		form.AddField("password", password);

		WWW w = new WWW("http://localhost:/action_login.php", form);

		yield return w;

		if (string.IsNullOrEmpty (w.error)) {
			User user = JsonUtility.FromJson<User> (w.text);
			if (user.success == true) 
			{
				if (user.error != "") 
				{
					textFeedback.text = user.error;
				} else 
				{
					textFeedback.text = "login successful.";
					Application.LoadLevel("Level1");
					//ProcessPlay (user);
				}
			} else {
				textFeedback.text = "An error occured";
			}

			// todo: launch the game (player)
		} else {
			// error
			textFeedback.text = "An error occured.";
		}
	}

	public IEnumerator RequestUserRegistration(){
		string email = textEmail.text;
		string password = textPassword.text;
		string reenterPassword = textConfirmPassword.text;

		if (password.Length < 8) {
			textFeedback.text = "password needs to be at least 8 characters long.";
			yield break;
		}
		if(password != reenterPassword) {
			textFeedback.text = "password do not match";
			yield break;
		}

		form = new WWWForm();
		form.AddField("email", email);
		form.AddField("password", password);

		WWW w = new WWW("http://localhost:/action_register.php", form);
		yield return w;

		if (string.IsNullOrEmpty (w.error)) {
			User user = JsonUtility.FromJson<User> (w.text);
			if (user.success == true) {
				if (user.error != "") {
					textFeedback.text = user.error;
				} else {
					textFeedback.text = "Registration Successful.";
					Application.LoadLevel("Level1");
					//ProcessPlay (user);
				}
			}
			else {
				textFeedback.text = "An error occured";
			}
		}
		}
}
