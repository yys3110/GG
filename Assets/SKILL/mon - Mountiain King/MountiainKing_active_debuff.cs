using UnityEngine;
using System.Collections;

public class MountiainKing_active_debuff : MonoBehaviour {
	public int turn = 2;
	int turn_max;
	player player_info;

	// Use this for initialization
	void Start () {
		turn_max = play_system.game_turn;
		player_info = transform.parent.GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player_info.character_select == true){
			player_info.field_UI.GetComponent<ui_field_system>().ui_move_bool = false;
		}
		if(player_info.character_select == false){
			player_info.field_UI.GetComponent<ui_field_system>().ui_move_bool = true;
		}
		if(play_system.game_turn > turn_max+ turn){
			player_info.field_UI.GetComponent<ui_field_system>().reset_bool();
			Destroy(gameObject);
		}
	
	}
}
