using UnityEngine;
using System.Collections;
// 암화(Dark Fire): 근접한 적에게 턴마다 1의 데미지
public class DarkFire_passive : MonoBehaviour {
	public int damage = 1;
	public float range = 10;
	public bool one_passive = true;
	public GameObject fire_effect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "monster" && (coll.transform.FindChild("darkFire_passive_debuff(Clone)") == null || coll.transform.GetComponentInChildren<Status_ailment_effect>().live == false)){
			GameObject fire = Instantiate(fire_effect,transform.position,fire_effect.transform.rotation) as GameObject;
			fire.transform.parent = coll.transform;
			fire.GetComponent<darkFire_passive_debuff>().taget = transform.gameObject;
		}
	}
	void OnTriggerExit(Collider coll){
		if(coll.gameObject.tag == "monster"){
			if(coll.gameObject.tag == "monster" && coll.transform.FindChild("darkFire_passive_debuff(Clone)") == null){
				GameObject fire = Instantiate(fire_effect,transform.position,fire_effect.transform.rotation) as GameObject;
				fire.transform.parent = coll.transform;
				fire.GetComponent<darkFire_passive_debuff>().taget = transform.gameObject;
			}
		}
	}
}
