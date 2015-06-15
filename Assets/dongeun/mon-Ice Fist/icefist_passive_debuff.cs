using UnityEngine;
using System.Collections;

public class icefist_passive_debuff : MonoBehaviour {
	public GameObject caster;
	int count = 0; // 게임 턴이 저장됨
	int MAX_count = 0;
	public int passive_turn = 2;
	int slow = 2; //슬로우값 2 = 50%
	int move = 0; // 초기 기동력값
	bool skill1 = false;
	bool skill2 = false;

	// Use this for initialization
	void Start () {
		count = play_system.game_turn+1;
		MAX_count = count + passive_turn;
		skill1 = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(count == play_system.game_turn){
			count ++;
			if(count == MAX_count){
				transform.parent.transform.gameObject.GetComponent<player>().move_range = move;
				Destroy(gameObject);
			}
		}
		if(skill1 == true && skill2 == false){
			move = transform.parent.transform.gameObject.GetComponent<player>().move_range;
			transform.parent.transform.gameObject.GetComponent<player>().move_range = 
				transform.parent.transform.gameObject.GetComponent<player>().move_range/slow;
			skill2 = true;
		}
	}
}
