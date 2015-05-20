using UnityEngine;
using System.Collections;

public class rage_buff : MonoBehaviour {
	public int buff = 0; //증가량 표시
	public int rage_hp = 0;
	// Use this for initialization
	void Start () {
		rage_hp = transform.parent.GetComponent<player>().hp_;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(rage_hp > transform.parent.GetComponent<player>().hp_){
			transform.parent.GetComponent<player>().add_damage++;
			buff++;
			rage_hp = transform.parent.GetComponent<player>().hp_;
		}
	}
}
