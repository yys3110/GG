﻿using UnityEngine;
using System.Collections;

public class Godsbody_passive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<monster>().defense = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
