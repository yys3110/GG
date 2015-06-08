using UnityEngine;
using System.Collections;
//영환 액티브스킬
public class soulballs_active : MonoBehaviour {
	public int turn_colltime;
	public GameObject soulballs_range;
	public int range_collider;
	public GameObject debuff;

	float del = 0;

	// Use this for initialization
	void Start () {
		soulballs_range.GetComponent<range_collider>().range_ = range_collider;
		Instantiate(soulballs_range,new Vector3(transform.position.x,0,transform.position.z),
		            soulballs_range.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<SphereCollider>().radius += 1;
		
		if(transform.GetComponent<SphereCollider>().radius >=30)
		{
			transform.GetComponent<SphereCollider>().radius = 0;
			Destroy(gameObject);
			hexagon.move_end = true;
			transform.parent.gameObject.GetComponent<monster>().wait_();
		}
	}
	void OnTriggerEnter(Collider coll){


		if(coll.gameObject.tag == "player" && coll.gameObject.GetComponent<player>().range_collider == true){
			GameObject child = Instantiate(debuff,transform.position,debuff.transform.rotation) as GameObject;
				Debug.Log("죽어라!");
				child.transform.parent = coll.transform;
				child.GetComponent<soulballs_active_debuff>().caster = transform.parent.transform.gameObject;
		}
	}
}