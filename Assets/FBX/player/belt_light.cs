using UnityEngine;
using System.Collections;

public class belt_light : MonoBehaviour {

	public GameObject belt_color;

	// Use this for initialization
	void Start () {
		GetComponent<Light>().color = belt_color.GetComponent<Renderer>().material.color;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
