using UnityEngine;
using System.Collections;
//영환 액티브 디버프
public class soulballs_active_debuff : MonoBehaviour {
	public GameObject caster;
	int count = 0;
	int MAX_count = 0;
	int move = 0;// move_range초기값 저장
	int miss = 0;// miss초기값 저장
	public int active_turn; // 디버프쿨타임 이 스킬은 1턴
	// Use this for initialization
	void Start () {
		count = play_system.game_turn+1;
		MAX_count =count + active_turn + 1;
		move = transform.parent.transform.gameObject.GetComponent<player>().move_range;
		miss = transform.parent.transform.gameObject.GetComponent<player>().miss;
	}
	
	// Update is called once per frame
	void Update () {
		if(count == MAX_count){

			transform.parent.gameObject.GetComponent<player>().move_range = move;
			transform.parent.gameObject.GetComponent<player>().miss = miss;
			Destroy(gameObject);
		}
		if(count == play_system.game_turn){
			count ++;
			transform.parent.gameObject.GetComponent<player>().move_range = transform.parent.transform.gameObject.GetComponent<player>().move_range / 2;
			transform.parent.gameObject.GetComponent<player>().miss = transform.parent.transform.gameObject.GetComponent<player>().miss / 2;
		}
		if(play_system.turn == 1){
			if(play_system.dice_active_num == 6){
				transform.parent.gameObject.GetComponent<player>().damage = transform.parent.transform.gameObject.GetComponent<player>().damage / 2;
			}
		}
	}
}
