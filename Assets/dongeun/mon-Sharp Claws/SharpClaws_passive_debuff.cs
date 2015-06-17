using UnityEngine;
using System.Collections;

public class SharpClaws_passive_debuff : MonoBehaviour {
	public GameObject caster;
	public int bleeding; //출혈 데미지
	int count = 0;
	int MAX_count = 0;
	public int passive_turn = 3;
	// Use this for initialization
	void Start () {
		count = play_system.game_turn+1;
		MAX_count = count + passive_turn;
	}
	// Update is called once per frame
	void Update () {
		if(count == play_system.game_turn){
			count ++;
			if(count == MAX_count){
				Destroy(gameObject);
			}
			transform.parent.transform.gameObject.GetComponent<player>().HP_system(bleeding,false,transform.parent.gameObject,1);
		}

	}
}
