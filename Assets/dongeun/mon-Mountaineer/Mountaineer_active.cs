using UnityEngine;
using System.Collections;

public class Mountaineer_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject Mountain_range;
	public int range_collider; //collider프리팹 범위
	// Use this for initialization
	void Start () {
		//collider프리팹 소환
		
		Mountain_range.GetComponent<hex_collider>().range_ = range_collider;
		Instantiate(Mountain_range,transform.position,Mountain_range.transform.rotation);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(hex_collider.collider_complete == true){
			gameObject.GetComponent<SphereCollider>().radius += 1;
		}
		if(gameObject.GetComponent<SphereCollider>().radius >=30)
		{
			hex_collider.collider_complete = false;
			Destroy(gameObject);
			hexagon.move_end = true;
		}
	}
	void OnTriggerEnter(Collider coll){
		player Mountain = coll.GetComponent<player>();
		
		if(coll.gameObject.tag == "player" && coll.gameObject.GetComponent<player>().range_collider == true){
			Mountain.hp_--;
		}
	}
}