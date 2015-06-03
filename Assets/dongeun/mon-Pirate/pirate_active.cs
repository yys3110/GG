using UnityEngine;
using System.Collections;

public class pirate_active : MonoBehaviour {
	public int turn_cooltime;

	// Use this for initialization
	void Start () {
		play_system.turn = 2;
		play_system.dice_active_num = 2;
		transform.parent.gameObject.GetComponent<monster>().dice_code_number = 0;
		transform.parent.gameObject.GetComponent<monster>().attack_();

	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 1)
		{
			transform.parent.gameObject.GetComponent<monster>().dice_code_number = 0;
			monster.skill_active = 0;
		}
	}
}
