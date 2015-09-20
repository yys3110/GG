using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//3칸 내의 적 1명 2턴간 이동불가(2턴) Mountain 지형에서만 사용가능
public class MountiainKing_active : MonoBehaviour {
	public int Range = 3;
	public int move_hold_turn = 2;
	public GameObject range_collider;
	public GameObject debuff;
	float del =0;
	monster mon_info;
	List<GameObject> player_list = new List<GameObject>();
	// Use this for initialization
	void Start () {
		mon_info = transform.parent.GetComponent<monster>();
		player_list = play_system.monster_target;
		hexagon.move_end = false;
		GameObject range_ = Instantiate(range_collider,transform.position + new Vector3(0,-5,0),range_collider.transform.rotation) as GameObject;
		range_.GetComponent<range_collider>().range_ = Range;
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;

		if(del >= 0.5f){
			if(mon_info.terrain_type == 4 || mon_info.terrain_type == 5){
				for(int i = 0; i< player_list.Count; i++){
					if(player_list[i].GetComponent<player>().range_collider == true)
					{
						GameObject debuff_ = Instantiate(debuff) as GameObject;
						debuff_.transform.parent = player_list[i].transform;
						Debug.Log("MountiainKing_active");
						break;
					}
				}
				mon_info.wait_();
				Destroy(gameObject);
			}
		}
	}
}
