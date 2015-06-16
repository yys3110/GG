using UnityEngine;
using System.Collections;

public class PoisonTooth_passive_debuff : MonoBehaviour {
	int turn_count;
	int max_turn;
	public int damage = 1;
	public GameObject caster;
	// Use this for initialization
	void Start () {
		turn_count = play_system.game_turn +1;
		max_turn = turn_count +3;
		transform.parent.GetComponent<monster>().HP_system(damage,false,caster,3);
		turn_count ++;
	}
	
	// Update is called once per frame
	void Update () {
		if(turn_count == play_system.game_turn){
			transform.parent.GetComponent<monster>().HP_system(damage,false,caster,3);
			turn_count ++;
			if(turn_count == max_turn)
				Destroy(gameObject);
		}
	
	}
}
