using UnityEngine;
using System.Collections;

public class icefist_passive : MonoBehaviour {
	public bool on_skill = false;
	public int passive_turn = 0;
	public GameObject target_unit;
	public bool turn = false;
	public bool slow_turn = false;
	int slow = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		target_unit = transform.parent.GetComponent<monster>().target;
		if(play_system.turn == 2){
			if(play_system.dice_active_num == 6){
				passive_turn = play_system.game_turn;
				on_skill = true;
				if(slow_turn == true){
					slow = 1;
				}
			}
		}
		if(play_system.turn == 1){
			if(passive_turn+2 >= play_system.game_turn && on_skill == true && turn == false && slow_turn == false){
				target_unit.GetComponent<player>().move_range = target_unit.GetComponent<player>().move_range/slow;
				Debug.Log ("으앙 얼음");
				turn = true;
				slow_turn = true;
			}
			if(passive_turn+3<= play_system.game_turn && on_skill == true){
				
				Debug.Log("땡");
				passive_turn = 0;
				on_skill = false;
				slow_turn = false;
				slow = 2;
				target_unit.GetComponent<player>().move_range = target_unit.GetComponent<player>().move_range*slow;
			}
		}
		if(turn == true && play_system.turn == 2){
			Debug.Log("적턴");
			turn = false;
		}
	}
}
