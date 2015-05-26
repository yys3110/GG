using UnityEngine;
using System.Collections;

public class SharpClaws_passive : MonoBehaviour {
	public bool on_skill = false;
	public int passive_turn = 0;
	public GameObject target_unit;
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		target_unit = transform.parent.GetComponent<monster>().target;

		if(play_system.turn == 2){
			if(play_system.dice_active_num == 6){

				passive_turn = play_system.game_turn;
			}
		}
		if(play_system.turn == 1 && on_skill == true){
			if(passive_turn+3 <= play_system.game_turn && on_skill == true){
				
				target_unit.GetComponent<player>().hp_ -= 1;
				Debug.Log (passive_turn+"독에 걸림");
				on_skill = false;
			}
		}
		if(play_system.turn == 2 && on_skill == false){
			on_skill = true;
		}
	}
}