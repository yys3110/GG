using UnityEngine;
using System.Collections;

public class Authority : MonoBehaviour {
	//권위
	//사거리 내의 적 공격력, 사거리, 기동력 -1 
	//사거리 내의 아군 재조작 가능(3턴)
	public int collider_range;// collider_range;
	public int damage,attack_range,move_range;
	public GameObject play_unit;

	// Use this for initialization
	void Start () {
		GetComponent<SphereCollider>().radius = collider_range;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider coll){
		if(coll.gameObject.tag == "monster"){
			coll.GetComponent<monster>().damage = coll.GetComponent<monster>().damage - damage;
			coll.GetComponent<monster>().attack_range = coll.GetComponent<monster>().attack_range - attack_range;
			coll.GetComponent<monster>().move_count = coll.GetComponent<monster>().move_count - move_range;

		}
	}
}
