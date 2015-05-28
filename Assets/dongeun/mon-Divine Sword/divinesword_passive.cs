using UnityEngine;
using System.Collections;

public class divinesword_passive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<monster>().add_damage = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
