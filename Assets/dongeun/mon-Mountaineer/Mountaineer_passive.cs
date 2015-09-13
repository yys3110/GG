using UnityEngine;
using System.Collections;

public class Mountaineer_passive : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 2 && play_system.monster_num == transform.parent.GetComponent<monster>().monster_number){
			monster unit_info = transform.parent.GetComponent<monster>();
			if(unit_info.terrain_type == 4 || unit_info.terrain_type == 5 ){
				unit_info.move_range = unit_info.temp_move_range;
			}
		}
	}
}
