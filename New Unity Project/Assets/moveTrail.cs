﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour {

	public int moveSpeed = 200;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * Time.deltaTime * moveSpeed);
		Destroy (this.gameObject, 1);
	}
}
