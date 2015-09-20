using UnityEngine;
using System.Collections;

public class command_active_buff : MonoBehaviour {
	public int move_range = 1;
	public int attack_range = 1;
	public int turn_buff = 1;
	monster mon;
	int max_count =0;
	// Use this for initialization
	void Start () {
		mon = transform.parent.GetComponent<monster>();
		mon.move_range += 1;
		mon.attack_range += 1;
		max_count = play_system.game_turn;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.game_turn > max_count+turn_buff){
			mon.move_range -= 1;
			mon.attack_range -= 1;
			Destroy(gameObject);
		}
	
	}
}
