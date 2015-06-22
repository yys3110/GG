using UnityEngine;
using System.Collections;

public class swordemperor_passive : MonoBehaviour {
	public GameObject player_unit;

	int dice = 0;
	int hp = 0;
	int num = 0;
	float del = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 2){
			player_unit = transform.parent.transform.gameObject.GetComponent<monster>().target;
			if(play_system.dice_active_num == 5){
				dice = play_system.play_dice_num;
				hp = player_unit.GetComponent<player>().hp_;
				num = dice - hp;
			if(num >= 0 && play_system.dice_active_num == 6){
					transform.parent.transform.gameObject.GetComponent<monster>().target = play_system.monster_target[0].transform.gameObject;
					play_system.dice_active_num = 3;
					transform.parent.transform.gameObject.GetComponent<monster>().attack_();

				}
			}
		}


	}
}
