using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

	private float currPos;
	public float oscSpeed;
	public float highPoint;
	public float lowPoint;
	private bool moveUp = true;

	// Use this for initialization
	void Start () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		currPos = transform.position.y;
		
	}
	
	// Update is called once per frame
	void Update () {

		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		if (moveUp) {
			if (transform.position.y >= currPos+highPoint) {
				moveUp = false;
			}
			transform.Translate(Vector2.up * oscSpeed * Time.deltaTime);
		}
		else if (!moveUp) {
			if (transform.position.y <= currPos+lowPoint) {
				moveUp = true;
			}
			transform.Translate(Vector2.down * oscSpeed * Time.deltaTime);
		}

	}
}
