using UnityEngine;
using System.Collections;

public class divinesword_active : MonoBehaviour {
	public GameObject target;
	public int turn_cooltime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		target = transform.parent.GetComponent<monster>().target;
		if(play_system.turn == 2){
			target.GetComponent<player>().HP_system(target.GetComponent<player>().hp_max/2,false,transform.parent.gameObject);
			Destroy(gameObject);
			transform.parent.gameObject.GetComponent<monster>().wait_();
		}
	}
}
