using UnityEngine;
using System.Collections;

public class StrongHealth_passive : MonoBehaviour {
	public int defense = 1;
	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<monster>().defense = transform.parent.GetComponent<monster>().defense + defense;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
