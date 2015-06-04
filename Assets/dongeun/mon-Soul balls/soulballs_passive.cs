using UnityEngine;
using System.Collections;

public class soulballs_passive : MonoBehaviour {
	public GameObject target_unit;
	int miss = 0; // 타겟된 플레이어의 초기 회피값 저장
	int defen = 0;// 타겟된 플레이어의 초기 방어값 저장
	// Use this for initialization
	void Start () {
		miss = target_unit.GetComponent<player>().miss;
		defen = target_unit.GetComponent<player>().defense;
	}
	
	// Update is called once per frame
	void Update () {
		target_unit = transform.parent.GetComponent<monster>().target;
		if(play_system.turn == 2){
			if(play_system.dice_active_num == 6){
				target_unit.GetComponent<player>().miss = 0;
				target_unit.GetComponent<player>().defense = 0;
			}
			if(transform.parent.GetComponent<monster>().pattern_num == 4){
				target_unit.GetComponent<player>().miss = miss;
				target_unit.GetComponent<player>().defense = defen;
			}
		}

	}
}
