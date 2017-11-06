using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerScript : MonoBehaviour {

	public GameObject PauseButton;
	public GameObject canvas;



	// Use this for initialization
	void Start () {
		Time.timeScale = 0F;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void playButton(){
		Time.timeScale = 1.0F;
		GameObject pauseBut = Instantiate (PauseButton) as GameObject;
		pauseBut.transform.SetParent (canvas.transform);
		pauseBut.transform.position = new Vector3 (474F, 175F, 0);
		Destroy (GameObject.Find ("toDelete"));

	}
}
