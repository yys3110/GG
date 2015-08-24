using UnityEngine;
using System.Collections;

public class Rush_passive : MonoBehaviour {
	public int add_move_range = 1; 

	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<monster>().move_range = transform.parent.GetComponent<monster>().move_range +add_move_range;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
