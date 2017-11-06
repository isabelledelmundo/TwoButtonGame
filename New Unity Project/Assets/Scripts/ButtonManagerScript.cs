using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour {

	public GameObject PauseButton;
	public GameObject PauseMenu;
	public GameObject SettingsMenu;

	private bool isPauseOpen;



	// Use this for initialization
	void Start () {
		Time.timeScale = 0F;
		isPauseOpen = false;
		PauseButton.SetActive(false);
		PauseMenu.SetActive(false);
		SettingsMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void playButton(){
		Time.timeScale = 1.0F;
		PauseButton.SetActive(true);
		Destroy (GameObject.Find ("toDelete"));

	}

	public void pauseButton(){
		if (!isPauseOpen) {
			Time.timeScale = 0F;
			PauseMenu.SetActive(true);
			isPauseOpen = true;
		} else {
			Time.timeScale = 1.0F;
			PauseMenu.SetActive(false);
			isPauseOpen = false;
		}
	}
		
	public void exitButton(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void storeButton(){
		Time.timeScale = 1.0F;
		PauseButton.SetActive(true);
		Destroy (GameObject.Find ("toDelete"));

	}

	public void settingsButton(){
		SettingsMenu.SetActive(true);
	}

	public void soundButton(){
		
	}

	public void musicButton(){
		
	}

	public void backButton(){
		SettingsMenu.SetActive(false);
	}
}
