using UnityEngine;
using System.Collections;
//신령 스킬
public class HolyGhost_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject heal_range;
	public int range_collider; //collider프리팹 범위
	// Use this for initialization
	void Start () {
		//collider프리팹 소환

		heal_range.GetComponent<hex_collider>().range_ = range_collider;
		Instantiate(heal_range,transform.position,heal_range.transform.rotation);
		transform.parent.GetComponent<monster>().hp_++;

	}

	// Update is called once per frame
	void Update () {
		if(hex_collider.collider_complete == true){
		gameObject.GetComponent<SphereCollider>().radius += 5;
		}
		if(gameObject.GetComponent<SphereCollider>().radius >=30)
		{
			hex_collider.collider_complete = false;
			Destroy(gameObject);
			hexagon.move_end = true;
		}
	}
	void OnTriggerEnter(Collider coll){
		monster heal = coll.GetComponent<monster>();

		if(coll.gameObject.tag == "monster" && coll.gameObject.GetComponent<monster>().range_collider == true){
				heal.hp_ ++;


			
		}
	}
}