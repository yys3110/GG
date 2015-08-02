using UnityEngine;
using System.Collections;

public class Bind_active_debuff : MonoBehaviour {
	public int skill_count = 2;

	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3(0,0,-1);

	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponentInParent<monster>().monster_number == play_system.monster_num && play_system.turn == 2){
			skill_count --;
			GetComponentInParent<monster>().wait_();
		}
		if(skill_count <=0)
			Destroy(gameObject);
	}
}
