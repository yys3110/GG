using UnityEngine;
using System.Collections;

public class MountiainKing_passive : MonoBehaviour {
	//Mountain 지형에서 기동력 유지, 공격력+1
	int terrain_num = 0;
	bool one_buff_bool = true;
	bool Buff_on = false;
	monster parent_info;
	// Use this for initialization
	void Start () {
		parent_info  = transform.parent.GetComponent<monster>();
	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.monster_num == parent_info.monster_number && play_system.turn ==2){
			if(parent_info.terrain_type == 4||parent_info.terrain_type == 5){
				Buff_on = true;
			}
			if(!(parent_info.terrain_type == 4||parent_info.terrain_type == 5)){
				Buff_on = false;
			}
			if(Buff_on == true){
				if(one_buff_bool == true){
					parent_info.add_damage += 1;
					one_buff_bool = false;
				}
			}
			if(Buff_on == false){
				if(one_buff_bool ==false){
					parent_info.add_damage -=1;
					one_buff_bool = true;
				}
			}
		}
	}
}
