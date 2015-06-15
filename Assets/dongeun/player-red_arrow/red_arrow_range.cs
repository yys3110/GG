using UnityEngine;
using System.Collections;

public class red_arrow_range : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay (Collider coll){
		red_arrow arrow = transform.parent.GetComponent<red_arrow>();
		if(coll.gameObject.tag == "monster")
		{
			//water_wave wave = transform.parent.GetComponent<water_wave>();
			if(arrow.one_bool == false){
				coll.GetComponent<monster>().HP_system(arrow.damage,false,
				                                       arrow.transform.parent.gameObject,0);
				Destroy(transform.parent.gameObject);
			}
		}
		
		if(arrow.one_bool == false)
		{
			hexagon.move_end = true;
			Destroy(transform.parent.gameObject);
		}
	}
}
