using UnityEngine;
using System.Collections;

public class icefist_active_debuff : MonoBehaviour {
	player player_;
	float del =0;
	// Use this for initialization
	void Start () {
		player_ = transform.parent.GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(play_system.turn == 1){
			player_.character_select = false;
			if(del >= 0.5f){
				transform.parent.GetComponent<player>().wait_();
				Destroy(gameObject);
			}
		}
	}
}
