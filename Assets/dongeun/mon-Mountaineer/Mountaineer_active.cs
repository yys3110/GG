using UnityEngine;
using System.Collections;

public class Mountaineer_active : MonoBehaviour {
	public int turn = 2;
	int max_count =0;
	bool buff_on = false;
	bool one_bool = true;
	GameObject target;
	void Start () {
		max_count = play_system.game_turn + (turn*2) ;
	}
	
	// Update is called once per frame
	void Update () {

		if(play_system.monster_num == transform.parent.GetComponent<monster>().monster_number){
			monster mon = transform.parent.GetComponent<monster>();
			float distance = Vector3.Distance(transform.parent.transform.position,mon.target.transform.position);
			if(distance >= 15){
				buff_on = true;
			}
			else if(distance < 15){
				buff_on = false;
			}
		}
		if(buff_on == true && one_bool == true){
			transform.parent.GetComponent<monster>().add_damage += 1;
			one_bool = false;
		}
		if(buff_on == false && one_bool == false){
			transform.parent.GetComponent<monster>().add_damage -= 1;
			one_bool = true;
		}

		if(play_system.game_turn >= max_count){
			if(buff_on == true){
				transform.parent.GetComponent<monster>().add_damage -= 1;
				Destroy(gameObject);
			}
			if(buff_on == false){
				Destroy(gameObject);
			}
		}
	}
}