using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {
	public int damage =0;
	public float radius =0; // 10 : 1칸 , 18 2칸
	public int player_number = 0; // 0 중립 , 1 플레이어 , 2 몬스터

	// Use this for initialization
	void Start () {
		GetComponent<SphereCollider>().radius = radius;
		Debug.Log(damage);
		Destroy(gameObject,0.5f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(player_number == 1){
			if(coll.gameObject.tag == "monster"){

			}
		}
		if(player_number == 2){
			if(coll.gameObject.tag == "player"){
				Debug.Log("shlash damage hit " + damage);
				coll.GetComponent<player>().HP_system(damage,false);
			}
		}
	}
}
