using UnityEngine;
using System.Collections;
//신령 스킬
public class HolySpirit_active : MonoBehaviour {
	public int turn_cooltime;
	//public GameObject heal_range;
	//public int range_collider; //collider프리팹 범위
	// Use this for initialization
	void Start () {
		//collider프리팹 소환...;;

		//heal_range.GetComponent<hex_collider>().range_ = range_collider;
		//Instantiate(heal_range,transform.position,heal_range.transform.rotation);
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider coll){
		monster heal = coll.GetComponent<monster>();
		if(coll.gameObject.tag == "monster"){
				heal.hp_ ++;
			Destroy(gameObject);
			
		}
	}
}