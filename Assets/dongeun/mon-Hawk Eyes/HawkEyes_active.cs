using UnityEngine;
using System.Collections;

public class HawkEyes_active : MonoBehaviour {
	public int turn_cooltime; //스킬 쿨타임
	public int active_turn;   //스킬 지속턴
	public int HawkEyes_attack_range;
	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<monster>().attack_range += HawkEyes_attack_range;
		active_turn = play_system.game_turn + 3;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
