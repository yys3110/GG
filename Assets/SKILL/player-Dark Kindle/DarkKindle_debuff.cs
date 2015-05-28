using UnityEngine;
using System.Collections;

public class DarkKindle_debuff : MonoBehaviour {
	public int turn_count;
	int max_count =0;
	// Use this for initialization
	void Start () {
		max_count = play_system.game_turn  + turn_count;
	}
	
	// Update is called once per frame
	void Update () {

		if(play_system.turn == 2 && play_system.monster_num == transform.parent.GetComponent<monster>().monster_number){
			transform.parent.GetComponent<monster>().wait_();
		}
		if(max_count == play_system.game_turn){
			Destroy(gameObject);
		}
	
	}
}
