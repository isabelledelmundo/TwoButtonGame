using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

	public float movespeed;
	public float jumpSpeed;
	private bool isGrounded;

	public Text scoreText;
	public Text bankText;
	private int score;
	private int bank;

	private bool skip; //Use to not jump when player hits play button

	//Variables for gun shooting, might change these to a different class later if choose to add new weapons
	public float damage = 10;
	public LayerMask whatToHit;
	float timeToFire = 0;
	Vector2 shootDir = Vector2.right;
	Transform firePoint;
	public Transform bulletTrail;


	// Use this for initialization
	void Start () {
		score = 0;
		isGrounded = true;
		firePoint = transform.Find ("FirePoint");
		skip = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		//Updating the score text
		scoreText.text = score.ToString ();

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
			if (!skip) {
				if (touch/*.position.x*/ < Screen.width / 2) {
					if (isGrounded) {
						rb.velocity += jumpSpeed * Vector2.up;
						isGrounded = false;
					}
				} else if (Time.deltaTime>0.0001) {
					Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
					RaycastHit2D hit = Physics2D.Raycast (firePointPosition, shootDir, 100, whatToHit);
					Instantiate (bulletTrail, firePoint.position, firePoint.rotation);
				}
			} else
				skip = false;
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
			score++;	//Worth 1 point
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "RubyCoin") {
			score += 3;	//Worth 10 points
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "DiamondCoin") {
			score += 10;	//Worth 50 points
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "Enemy") {
			bank += score;
			//player dies
			//display game over
			//scene resets with main menu but amount in bank remains
		}
	}
}
