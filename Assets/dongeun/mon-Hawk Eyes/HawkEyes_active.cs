using UnityEngine;
using System.Collections;

public class HawkEyes_active : MonoBehaviour {
	public int turn_cooltime; //스킬 쿨타임
	public int HawkEyes_attack_range; // 스킬
	int count = 0;
	int MAX_count = 0;
	public int active_turn = 2;   //스킬 지속턴
	// Use this for initialization
	void Start () {
		count = play_system.game_turn+1;
		MAX_count = count + active_turn;
		transform.parent.GetComponent<monster>().attack_range += HawkEyes_attack_range;
		transform.parent.GetComponent<monster>().skill_bool = false;
	}	
	// Update is called once per frame
	void Update () {
		
		if(count == play_system.game_turn){
			count ++;
			if(count == MAX_count){
				transform.parent.GetComponent<monster>().attack_range -= HawkEyes_attack_range;
				transform.parent.GetComponent<monster>().skill_bool = true;
				Destroy(gameObject);
			}
		}
	}
}
