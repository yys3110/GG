using UnityEngine;
using System.Collections;

public class Guard_active_buff : MonoBehaviour {
	public int defense =10;
	public int turn_ =1;
	public int max_hp;
	public int shield_point =0;
	int turn_count =0;

	// Use this for initialization
	void Start () {
		max_hp = transform.parent.GetComponent<player>().hp_;
		turn_count = play_system.game_turn + turn_;
		transform.localPosition += new Vector3(0,0,-0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent.GetComponent<player>().hp_<max_hp){
			shield_point = max_hp - transform.parent.GetComponent<player>().hp_;
			if(defense >= shield_point){
				transform.parent.GetComponent<player>().hp_ += shield_point;
				defense -= shield_point;
			}
			if(defense < shield_point){
				transform.parent.GetComponent<player>().hp_ += defense;
				Destroy(gameObject);
			}
		}
		if(transform.parent.GetComponent<player>().hp_>max_hp){
			max_hp = transform.parent.GetComponent<player>().hp_;
		}
		if(turn_count == play_system.game_turn){
			Destroy(gameObject);
		}
	}
}
