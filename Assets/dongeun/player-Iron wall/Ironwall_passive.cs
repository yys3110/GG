using UnityEngine;
using System.Collections;

public class Ironwall_passive : MonoBehaviour {
	public int melee_attack_def;
	public int ranged_attack_def;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 2){
			if(play_system.dice_active_num == 6){
				if(play_system.playing_uint.GetComponent<monster>().target_distance <=10){
					transform.parent.transform.gameObject.GetComponent<player>().defense = melee_attack_def;
				}
				if(play_system.playing_uint.GetComponent<monster>().target_distance >=10){
					transform.parent.transform.gameObject.GetComponent<player>().defense = ranged_attack_def;
				}
			}
		}
	}
}