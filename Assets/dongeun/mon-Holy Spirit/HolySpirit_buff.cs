using UnityEngine;
using System.Collections;

public class HolySpirit_buff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "monster"){
			monster heal = coll.GetComponent<monster>();
			heal.defense = 1;
		}
	}
}
