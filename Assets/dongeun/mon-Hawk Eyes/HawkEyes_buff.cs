﻿using UnityEngine;
using System.Collections;

public class HawkEyes_buff : MonoBehaviour {
	public int buff_miss;
	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<monster>().miss += buff_miss;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}