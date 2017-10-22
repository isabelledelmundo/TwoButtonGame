using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour {

	public int movespeed = 1;
	public float jumpSpeed;
	private Vector3 userDirection = Vector3.right;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {

		Rigidbody rb = GetComponent<Rigidbody>();

		//Keep moving forwards infinitely
		transform.Translate(userDirection * movespeed * Time.deltaTime); 


		if (transform.position.x >= 9.8f) {
			transform.position = new Vector3 (-9.8f, transform.position.y, transform.position.z);
		}

		if (Input.touchCount == 1)
		{
			var touch = Input.touches[0];
			if (touch.position.x < Screen.width/2)
			{
				rb.velocity += jumpSpeed * Vector3.up;
			}
			else if (touch.position.x > Screen.width/2)
			{
				//shoot
			}
		}
		
	}
}
