using UnityEngine;
using System.Collections;
//폭신 엑티브
public class ExplosionBody_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject Explosion_range;
	public int range_collider; //collider프리팹 범위
	// Use this for initialization
	void Start () {
		//collider프리팹 소환
		
		Explosion_range.GetComponent<range_collider>().range_ = range_collider;
		Instantiate(Explosion_range,transform.position,Explosion_range.transform.rotation);
		
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
		player Explosion = coll.GetComponent<player>();
		
		if(coll.gameObject.tag == "player" && coll.gameObject.GetComponent<player>().range_collider == true){
			Explosion.hp_--; // 고정 데미지
			transform.parent.GetComponent<monster>().die_bool = true; // 자폭으로 죽음
		}
	}
}
