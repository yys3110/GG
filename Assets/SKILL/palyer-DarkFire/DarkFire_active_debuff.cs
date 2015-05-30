using UnityEngine;
using System.Collections;

public class DarkFire_active_debuff : MonoBehaviour {
	public GameObject caster;
	public int trun_count=0;
	public int turn_damage =2; // 몇턴간 데미지를 줄건지를 결정
	public int damage =2;
	int max_turn = 0;

	// Use this for initialization
	void Start () {
		trun_count = play_system.game_turn +1;
		max_turn = trun_count + turn_damage;
		transform.localPosition += new Vector3(0,1.25f,0);
		transform.localScale += new Vector3(0.1f,0.1f,0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(trun_count <= play_system.game_turn){
			transform.parent.GetComponent<monster>().HP_system(damage,false,caster);
			trun_count ++;
			if(max_turn == trun_count)
			{
				GetComponent<Status_ailment_effect>().live = false;
			}
		}
	}
}
