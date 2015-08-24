using UnityEngine;
using System.Collections;

public class Flowingwater_passive : MonoBehaviour {
	public int terrain_num =0;
	public int defense = 3;
	bool passive_on = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		terrain_num = transform.parent.GetComponent<player>().terrain_type;

		switch(terrain_num){
		case 6:
			if(passive_on == false){
			transform.parent.GetComponent<player>().defense = transform.parent.GetComponent<player>().defense + defense;
			passive_on = true;
			}
			break;
		
		case 8: 
			if(passive_on == false){
				transform.parent.GetComponent<player>().defense = transform.parent.GetComponent<player>().defense + defense;
				passive_on = true;
			}
			break;
		
		case 9: 
			if(passive_on == false){
				transform.parent.GetComponent<player>().defense = transform.parent.GetComponent<player>().defense + defense;
				passive_on = true;
			}
			break;
		
		default:
			if(passive_on == true){
				transform.parent.GetComponent<player>().defense = transform.parent.GetComponent<player>().defense - defense;
				passive_on = false;
			}
			break;
		}
	}
}
