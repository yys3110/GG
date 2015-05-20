using UnityEngine;
using System.Collections;
// 유수 범위
public class FlowingWater_range : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider coll){
		FlowingWater wave = transform.parent.GetComponent<FlowingWater>();
		if(coll.gameObject.tag == "monster")
		{
			//water_wave wave = transform.parent.GetComponent<water_wave>();
			if(wave.one_bool == false){
				coll.GetComponent<monster>().hp_ -= transform.parent.GetComponent<FlowingWater>().damage;
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
