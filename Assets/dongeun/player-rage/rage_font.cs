using UnityEngine;
using System.Collections;

public class rage_font : MonoBehaviour {
	float a = 2f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,2f);
	}
	
	// Update is called once per frame
	void Update () {
		a -= Time.deltaTime;
		transform.position += new Vector3(0,2.5f,0)* Time.deltaTime;
		GetComponent<Renderer>().material.color = new Color(1,1,1,a);
	}
}
