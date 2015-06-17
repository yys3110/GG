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
		play_system.skill_cast = true;
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
		heal_range.GetComponent<range_collider>().range_ = range_collider;
		Instantiate(heal_range,transform.position,heal_range.transform.rotation);
		transform.parent.gameObject.GetComponent<monster>().HP_system(1,false,null,4);

	}

	// Update is called once per frame
	void Update () {
		transform.GetComponent<SphereCollider>().radius += 0.5F;

		if(transform.GetComponent<SphereCollider>().radius >=30)
		{
			transform.GetComponent<SphereCollider>().radius = 0;
			hexagon.move_end = true;
			play_system.skill_cast = false;
			transform.parent.gameObject.GetComponent<monster>().wait_();
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider coll){
		monster heal = coll.GetComponent<monster>();

		if(coll.gameObject.tag == "monster"&& coll.gameObject.GetComponent<monster>().range_collider == true){
			heal.HP_system(1,false,null,4);
		}
	}
}