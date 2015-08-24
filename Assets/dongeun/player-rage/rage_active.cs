using UnityEngine;
using System.Collections;

public class rage_active : MonoBehaviour {
	public int skill = 0;
	public GameObject range_collider;
	int turn = 0;
	bool move_bool= false;
	public GameObject Error_font;
	bool one_font = true;
	bool skill_on = false;
	// Use this for initialization
	void Start () {
		move_bool = transform.parent.GetComponent<player>().field_UI.GetComponent<ui_field_system>().ui_move_bool;
		
		if(move_bool == true){
			hexagon.move_end = false;
			GameObject range = Instantiate(range_collider,transform.parent.transform.position - new Vector3(0,5,0),range_collider.transform.rotation) as GameObject;
			range.GetComponent<range_collider>().range_ =  transform.parent.GetComponent<player>().attack_range;
			turn = play_system.game_turn;
			skill = transform.parent.GetComponent<player>().move_range;
			transform.parent.GetComponent<player>().add_damage += skill;
			transform.parent.GetComponent<player>().active_num = 2;
			transform.parent.GetComponent<player>().temp_skillCollTime = 0;
			skill_on = true;
		}
		if(move_bool == false){
			transform.parent.GetComponent<player>().temp_skillCollTime = transform.parent.GetComponent<player>().skill_CollTime;
			if(one_font == true){
				Instantiate(Error_font,transform.parent.transform.position,Error_font.transform.rotation);
				one_font = false;
				transform.parent.GetComponent<player>().one_skill_bool = true;
				transform.parent.GetComponent<player>().field_UI.SetActive(true);
				transform.parent.GetComponent<player>().active_num = 0;
				Destroy(gameObject);
			}

		}
	}
	// Update is called once per frame
	void Update () {
		if(turn+2 == play_system.game_turn && skill_on == true){
			turn++;
			transform.parent.GetComponent<player>().add_damage -= skill;
			Destroy(gameObject);
		}
	}
}
