using UnityEngine;
using System.Collections;

public class magicpower_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject magic_range;
	public int range_collider; //collider프리팹 범위
	public int magic_damage;
	//public bool coll = false;
	GameObject magic_target;
	int man = 0;
	float time = 0;
	// Use this for initialization
	void Start () {
		//collider프리팹 소환
		play_system.skill_cast = true;
		magic_range.GetComponent<range_collider>().range_ = range_collider;
		Instantiate(magic_range,new Vector3(transform.position.x,0,transform.position.z),magic_range.transform.rotation);
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<SphereCollider>().radius += 0.5F;

		if(transform.GetComponent<SphereCollider>().radius >=45)
		{
			magic_target.GetComponent<player>().HP_system(magic_damage,false,transform.parent.gameObject,1);
			hexagon.move_end = true;
			play_system.skill_cast = false;
			transform.parent.gameObject.GetComponent<monster>().wait_();
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider coll){

		if(coll.gameObject.tag == "player" && coll.GetComponent<player>().range_collider == true){
			man++;
			magic_target = coll.transform.gameObject;
			if(man <= 2){
				coll.GetComponent<player>().HP_system(magic_damage,false,transform.parent.gameObject,1);
				if(man == 2){
					hexagon.move_end = true;
					play_system.skill_cast = false;
					transform.parent.gameObject.GetComponent<monster>().wait_();
					Destroy(gameObject);
				}
			}
		}
	}
}