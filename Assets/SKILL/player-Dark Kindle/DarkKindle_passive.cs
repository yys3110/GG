using UnityEngine;
using System.Collections;
//암휘(Dark Kindle) 패시브 : 매 턴 첫 피격 회피
public class DarkKindle_passive : MonoBehaviour {
	public bool one_passive = true;
	public int add_miss = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
		if(play_system.turn == 2 && play_system.monster_num == 0){
			if(one_passive == true){
				transform.parent.GetComponent<player>().miss += add_miss;
				one_passive = false;
			}
		}
		if((play_system.turn == 2 && play_system.monster_num == 1) || play_system.turn ==1){
			if(one_passive == false){
				transform.parent.GetComponent<player>().miss -= add_miss;
				one_passive = true;
			}
		}
	}
}
