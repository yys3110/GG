using UnityEngine;
using System.Collections;

public class Authority_buff : MonoBehaviour {
	public float range_collider;
	public GameObject effect;
	// 사거리 내의 적 공격력, 사거리, 기동력 -1
	public int debuff_damage = 1;
	public int debuff_AttackRange = 1;
	public int debuff_MoveRange = 1;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 2){
			player p = transform.parent.GetComponent<player>();
			GetComponent<SphereCollider>().radius = range_collider;
		}
		else{
			//GetComponent<SphereCollider>().radius = 0;
		}
	}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "monster"){
			monster m = coll.GetComponent<monster>();
			m.damage = m.damage - debuff_damage;
			m.attack_range = m.attack_range -debuff_AttackRange;
			m.move_range = m.move_range - debuff_MoveRange;
			GameObject monster = coll.gameObject;
			GameObject child = Instantiate(effect,monster.transform.position,effect.transform.rotation) as GameObject;
			child.transform.parent = monster.transform;
			child.transform.localPosition += new Vector3(0,0,-1);

		}
	}
	void OnTriggerExit(Collider coll){
		if(coll.gameObject.tag == "monster"){
			Debug.Log("monster collider exit ");
			monster m = coll.GetComponent<monster>();
			m.damage = m.damage +debuff_damage;
			m.attack_range = m.attack_range +debuff_AttackRange;
			m.move_range = m.move_range +debuff_MoveRange;
			Debug.Log("end buff");
			GameObject monster = coll.gameObject;
			monster.GetComponentInChildren<Status_ailment_effect>().live = false;
		}
	}
}
