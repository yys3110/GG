using UnityEngine;
using System.Collections;
// 호위(Guard) :3칸 내의 아군 회피 +1
public class Guard_passive : MonoBehaviour {
	public GameObject buff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "player"){
			GameObject buff_child = Instantiate(buff,coll.transform.position,buff.transform.rotation) as GameObject;
			buff_child.transform.parent = coll.transform;
		}
	}
	void OnTriggerExit(Collider coll){
		if(coll.gameObject.tag == "player"){
			coll.GetComponentInChildren<Status_ailment_effect>().live = false;
		}
	}
}
