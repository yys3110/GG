using UnityEngine;
using System.Collections;
// 유수 범위
public class FlowingWater_range : MonoBehaviour {
	public GameObject FlowingWaterActive;
	// Use this for initialization
	void Start () {
		FlowingWaterActive = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay (Collider coll){
		Flowingwater_actve water = transform.parent.GetComponent<Flowingwater_actve>();
		if(coll.gameObject.tag == "monster")
		{
			//water_wave wave = transform.parent.GetComponent<water_wave>();
			if(water.one_bool == false){
				coll.GetComponent<monster>().HP_system(water.damage,false,
				                                       water.transform.parent.gameObject,0);
				Destroy(transform.parent.gameObject);
			}
		}
		
		if(water.one_bool == false)
		{
			hexagon.move_end = true;
			Destroy(transform.parent.gameObject);
		}
	}
}
