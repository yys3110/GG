using UnityEngine;
using System.Collections;

public class SharpClaws_passive : MonoBehaviour {
	public bool on_skill = false;
	public int passive_turn = 0;
	public GameObject target_unit;
	public bool turn = false;
	public int bleeding;
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
			}
		}
		if(play_system.turn == 1){
			if(passive_turn+3 >= play_system.game_turn && on_skill == true && turn == false){
				target_unit.GetComponent<player>().hp_ -= bleeding;
				Debug.Log ("으아아아아");
			turn = true;
			}
			if(passive_turn+3<= play_system.game_turn && on_skill == true){

				Debug.Log("지혈됨");
				passive_turn = 0;
				on_skill = false;
			}
		}
		if(turn == true && play_system.turn == 2){
			Debug.Log("적턴");
			turn = false;
		}
	}
}