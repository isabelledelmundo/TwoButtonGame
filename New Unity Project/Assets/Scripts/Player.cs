using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour {

	public int movespeed = 1;
	private Vector3 userDirection = Vector3.right;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(userDirection * movespeed * Time.deltaTime); 

		/*if left side of screen touched
		 * player jump
		 * else if right side of screen is touched
		 * player shoot
		 */
		
	}
}
