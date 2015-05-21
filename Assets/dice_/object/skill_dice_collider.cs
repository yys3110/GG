using UnityEngine;
using System.Collections;

public class skill_dice_collider : MonoBehaviour {
	public int collider_num;
	void Start(){
		collider_num =System.Convert.ToInt16(transform.name);
	}
	void OnTriggerStay(Collider coll){
		if(coll.gameObject.tag == "dice_collider_wall"){
			transform.parent.GetComponent<skill_dice>().collider_num = collider_num;
		}
	}
}
