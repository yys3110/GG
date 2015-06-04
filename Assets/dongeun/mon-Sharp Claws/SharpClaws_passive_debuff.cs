using UnityEngine;
using System.Collections;

public class SharpClaws_passive_debuff : MonoBehaviour {
	public GameObject caster;
	public int bleeding; //출혈 데미지
	int count = 0;
	int MAX_count = 0;
	public int passive_turn = 3;
	// Use this for initialization
	void Start () {
		count = play_system.game_turn+1;
		MAX_count = count + passive_turn;
	}
	// Update is called once per frame
	void Update () {
		/*if(play_system.turn == 2){
			if(play_system.dice_active_num == 6){
				passive_turn = play_system.game_turn;
				on_skill = true;
			}
		}
		if(play_system.turn == 1){
			if(passive_turn+3 >= play_system.game_turn && on_skill == true && turn == false){
				transform.parent.transform.gameObject.GetComponent<player>().HP_system(bleeding,false,transform.parent.gameObject);
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
		}*/
		if(count == play_system.game_turn){
			count ++;
			if(count == MAX_count){
				Destroy(gameObject);
			}
			transform.parent.transform.gameObject.GetComponent<player>().HP_system(bleeding,false,transform.parent.gameObject);
		}

	}
}
