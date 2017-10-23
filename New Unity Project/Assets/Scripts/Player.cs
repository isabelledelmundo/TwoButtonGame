using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour {

	public int movespeed = 1;
	public float jumpSpeed;
	private Vector3 userDirection = Vector3.right;
	private bool isGrounded = true;


	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {

		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		//Keep moving forwards infinitely
		transform.Translate(Vector2.right * movespeed * Time.deltaTime);


		//When reach end of screen, appear at other end
		if (transform.position.x >= 9.5f) {
			transform.position = new Vector3 (-9.5f, transform.position.y, transform.position.z);
		}


		//Detecting player press on left or right side of screen////for now we are using mouse click for testing purposes
		if (Input.GetMouseButtonDown(0)/*Input.touchCount == 1*/)
		{
			var touch = Input.mousePosition.x/*Input.touches[0]*/;
			if (touch/*.position.x*/ < Screen.width/2)
			{
				if (isGrounded) {
					rb.velocity += jumpSpeed * Vector2.up;
					isGrounded = false;
				}
			}
			else
			{
				//shoot
			}
		}

	}

	//Code to check if player is on the ground
	void OnCollisionEnter2D(Collision2D col){

		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	//Code to check the value of the coin being picked up
	void OnTriggerEnter2D(Collider2D col){

		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (col.gameObject.tag == "GoldCoin") {
			//add 1 point
			Destroy(col.gameObject);
		}
		else if (col.gameObject.tag == "RubyCoin") {
			//add 10 point
			Destroy(col.gameObject);
		}
		else if (col.gameObject.tag == "DiamondCoin") {
			//add 50 point
			Destroy(col.gameObject);
		}
	}
}
