using UnityEngine;
using System.Collections;

public class StrongHealth_passive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<monster>().defense = 1;
	}
}
