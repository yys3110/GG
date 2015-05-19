using UnityEngine;
using System.Collections;
//신령 스킬
public class HolySpirit_active : MonoBehaviour {
	//public GameObject heal_range;
	public int turn_cooltime;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "monster"){
			monster heal = coll.GetComponent<monster>();
			heal.hp_ ++;
			Destroy(gameObject);
		}
	}
}