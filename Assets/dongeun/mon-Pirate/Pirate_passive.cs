using UnityEngine;
using System.Collections;

public class Pirate_passive : MonoBehaviour {

	monster mon;
	bool buff_on = false;
	bool one_bool = true;
	// Use this for initialization
	void Start () {
		mon = transform.parent.GetComponent<monster>();
	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 2 && play_system.monster_num == mon.monster_number){
			if(mon.terrain_type == 7){
				buff_on =true;
			}
			if(mon.terrain_type != 7){
				buff_on =false;
			}
			if(buff_on == true){
				if(one_bool == true){
					mon.move_range += 1;
					one_bool = false;
				}
			}
			if(buff_on == false){
				if(one_bool == false){
					mon.move_range -= 1;
					one_bool = true;
				}
			}
		}
	
	}
}
