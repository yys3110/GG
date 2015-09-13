using UnityEngine;
using System.Collections;

public class ContinuousFire_passive : MonoBehaviour {
	bool buff_on = false;
	bool one_bool = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent.GetComponent<monster>().monster_number == play_system.monster_num && play_system.turn == 2){
			if(!(transform.parent.GetComponent<monster>().target == null)){
				monster mon = transform.parent.GetComponent<monster>();
				float distance = Vector3.Distance(transform.parent.transform.position,mon.target.transform.position);
				if(distance <=10){
					buff_on = true;
				}
				if(distance >10){
					buff_on = false;
				}
			}
		}
		if(buff_on == true && one_bool == true){
			transform.parent.GetComponent<monster>().add_damage += 1;
			one_bool = false;
		}
		else if(buff_on == false && one_bool == false){
			transform.parent.GetComponent<monster>().add_damage -= 1;
			one_bool = true;
		}
	}
}
