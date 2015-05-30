using UnityEngine;
using System.Collections;

public class Guard_passive_buff : MonoBehaviour {
	public int defense = 1;
	bool one_defense = true;
	// Use this for initialization
	void Start () {
		transform.localPosition += new Vector3(0,0,-0.5f);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Status_ailment_effect>().live == true && one_defense == true){
			transform.parent.GetComponent<player>().defense ++;
			one_defense = false;
		}
		if(GetComponent<Status_ailment_effect>().live == false && one_defense == false){
			transform.parent.GetComponent<player>().defense --;
			one_defense = true;
		}

	
	}
}
