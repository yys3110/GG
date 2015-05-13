﻿using UnityEngine;
using System.Collections;

public class hex_collider : MonoBehaviour {

	public float speed;
	public float range_= 2;
	public static bool collider_complete = false; // true가 되면 몬스터 move가 실행
	public static float [] range_collection = {2,3.5f,5,6.9f,8.6f,10.6f};


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.localScale.x <= range_)
		{
		transform.localScale += new Vector3 (10,transform.localScale.y,10) *speed* Time.deltaTime;
		}
		if(!(transform.localScale.x <= range_)){
			collider_complete = true;
			Destroy(gameObject);
		}

	
	}
}
