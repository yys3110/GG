using UnityEngine;
using System.Collections;
//흑풍(Black Wind) : 반경 3칸 내의 적에게 5의 데미지(4턴)+뒤로 한칸 밀어냄
public class BlackWind_active : MonoBehaviour {
	public GameObject range_collider;
	public GameObject debuff;
	public int range = 3;
	public GameObject caster;
	float del = 0;
	GameObject child;
	// Use this for initialization
	void Start () {
		hexagon.move_end = false;
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
		range_collider.GetComponent<range_collider>().range_ = range;
		Instantiate(range_collider,new Vector3(transform.position.x,0,transform.position.z),range_collider.transform.rotation);
		caster = play_system.playing_uint;

	}
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(del >= 0.2f){
			GetComponent<SphereCollider>().radius = 40;
		}
		if(del >=0.3f){
			caster.GetComponent<player>().wait_();
			Destroy(gameObject);
		}
	}
	void OnTriggerStay(Collider coll){
		if(coll.gameObject.tag == "monster" && coll.GetComponent<monster>().range_collider == true){
			if(coll.gameObject.transform.FindChild("BlackWind_active_debuff(Clone)") == null){
				child = Instantiate(debuff,transform.position,transform.rotation) as GameObject;
				child.transform.parent = coll.transform;
				child.GetComponent<BlackWind_active_debuff>().caster = caster;
			}

		}
	}
}
