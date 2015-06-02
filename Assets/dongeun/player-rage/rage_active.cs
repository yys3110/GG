using UnityEngine;
using System.Collections;

public class rage_active : MonoBehaviour {
	public int skill = 0;
	int turn = 0;
	// Use this for initialization
	void Start () {
		turn = play_system.game_turn;
		skill = transform.parent.GetComponent<player>().move_range;
		transform.parent.GetComponent<player>().add_damage += skill;

	}
	
	// Update is called once per frame
	void Update () {
		if(turn+2 == play_system.game_turn){
			turn++;
			transform.parent.GetComponent<player>().add_damage -= skill;
			Destroy(gameObject);
		}
	}
}
