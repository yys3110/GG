using UnityEngine;
using System.Collections;

public class water_wave_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider coll){
		water_wave wave = transform.parent.GetComponent<water_wave>();
		if(coll.gameObject.tag == "monster")
		{
			//water_wave wave = transform.parent.GetComponent<water_wave>();
			if(wave.one_bool == false){
			coll.GetComponent<monster>().hp_ -= transform.parent.GetComponent<water_wave>().damage;
			Destroy(transform.parent.gameObject);
			}
		}

		if(wave.one_bool == false)
		{
			hexagon.move_end = true;
			Destroy(transform.parent.gameObject);
		}
	}
}
