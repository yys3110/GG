using UnityEngine;
using System.Collections;

public class dice_collider : MonoBehaviour {


	public int collider_num;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	
	}

	void OnTriggerStay(Collider coll){
		if(coll.gameObject.tag == "dice_collider_wall"){
			transform.parent.GetComponent<dice>().collider_num = collider_num;
		}

	}


}
