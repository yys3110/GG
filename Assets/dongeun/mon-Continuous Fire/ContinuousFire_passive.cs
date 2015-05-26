using UnityEngine;
using System.Collections;

public class ContinuousFire_passive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "player"){
			transform.parent.GetComponent<monster>().add_damage = 1;
		}
	}
}
