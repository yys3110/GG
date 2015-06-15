using UnityEngine;
using System.Collections;

public class icefist_active_debuff : MonoBehaviour {
	public GameObject caster;
	public int passive_turn = 1;

	int count = 0; // 게임 턴이 저장됨
	int MAX_count = 0;

	// Use this for initialization
	void Start () {
		count = play_system.game_turn+1;
		MAX_count = count + passive_turn;
		transform.parent.transform.gameObject.GetComponent<player>().wait_();
	}
	
	// Update is called once per frame
	void Update () {
		if(count == play_system.game_turn){
			count ++;
			if(count == MAX_count){
				Destroy(gameObject);
			}
		}
	}
}
