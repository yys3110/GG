using UnityEngine;
using System.Collections;

public class Godsbody_active : MonoBehaviour {
	public int turn_cooltime;
	public bool game_turn1;
	public bool game_turn2;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 1 && game_turn1 == true){
			transform.parent.gameObject.GetComponent<monster>().range_collider = false;
			game_turn2 = false;
		}
		if(play_system.turn == 2 && game_turn2 == false){
			game_turn1 = false;
			Destroy(gameObject);
		}
	}
}