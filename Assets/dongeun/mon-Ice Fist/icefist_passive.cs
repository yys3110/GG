using UnityEngine;
using System.Collections;

public class icefist_passive : MonoBehaviour {
	public GameObject debuff;
	public GameObject target_unit;

	bool game_debuff = false;
	int count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		target_unit = transform.parent.GetComponent<monster>().target;
		if(play_system.turn == 2){
			if(play_system.dice_active_num == 6 && game_debuff == false){
				count = play_system.game_turn;
				GameObject child = Instantiate(debuff,transform.position,debuff.transform.rotation) as GameObject;
				child.transform.parent = target_unit.transform;
				child.GetComponent<icefist_passive_debuff>().caster = transform.parent.transform.gameObject;
				game_debuff = true;
			}
			if(count+3 <= play_system.game_turn){
				game_debuff = false;
			}
		}
	}
}
