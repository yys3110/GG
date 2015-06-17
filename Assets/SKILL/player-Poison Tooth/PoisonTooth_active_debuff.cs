using UnityEngine;
using System.Collections;

public class PoisonTooth_active_debuff : MonoBehaviour {
	int turn_count;
	int max_count;

	// Use this for initialization
	void Start () {
		turn_count = play_system.game_turn +=1;
		max_count = turn_count += 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(turn_count <= max_count){
			transform.parent.GetComponent<hexagon>().hexagon_unit_bool = true;
		}
		else{
			transform.parent.GetComponent<hexagon>().hexagon_unit_bool = false;
			Destroy(gameObject);
		}
	
	}
}
