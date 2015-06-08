using UnityEngine;
using System.Collections;

public class soulbody_passive_debuff : MonoBehaviour {
	public GameObject caster;
	int miss = 0; // 타겟된 플레이어의 초기 회피값 저장
	int defen = 0;// 타겟된 플레이어의 초기 방어값 저장
	// Use this for initialization
	void Start () {
		miss = transform.parent.gameObject.GetComponent<player>().miss;
		defen = transform.parent.gameObject.GetComponent<player>().defense;
	}
	
	// Update is called once per frame
	void Update () {
		transform.parent.gameObject.GetComponent<player>().miss = 0;
		transform.parent.gameObject.GetComponent<player>().defense = 0;
		if(play_system.turn == 1){
			transform.parent.gameObject.GetComponent<player>().miss = miss;
			transform.parent.gameObject.GetComponent<player>().defense = defen;
			Destroy(gameObject);
		}
	}
}
