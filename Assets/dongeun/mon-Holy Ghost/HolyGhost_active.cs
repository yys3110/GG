using UnityEngine;
using System.Collections;
//신령 스킬
public class HolyGhost_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject heal_range;
	public int range_collider; //collider프리팹 범위
	public bool coll = false;
	// Use this for initialization
	void Start () {
		//collider프리팹 소환

		heal_range.GetComponent<range_collider>().range_ = range_collider;
		Instantiate(heal_range,transform.position,heal_range.transform.rotation);
		transform.parent.GetComponent<monster>().hp_++;

	}

	// Update is called once per frame
	void Update () {
		transform.GetComponent<SphereCollider>().radius += 0.5F;

		if(transform.GetComponent<SphereCollider>().radius >=30)
		{
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