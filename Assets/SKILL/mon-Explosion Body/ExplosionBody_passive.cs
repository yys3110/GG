using UnityEngine;
using System.Collections;
//폭신 페시브
// 공격한 대상 주위로  데미지 의 20% 만큼 추가피해 최소피해 
public class ExplosionBody_passive : MonoBehaviour {
	public Vector3 player_pos;
	public bool one_passive = false;
	public GameObject range_collider;
	public int range = 1;
	public float collider_radius = 10;
	public GameObject effects_ExplosionBody;
	public GameObject splash;
	public float splash_damage = 0.2f; // 기본값 20%


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 2){

			if(play_system.monster_num == transform.parent.GetComponent<monster>().monster_number && play_system.dice_active_num == 6){
				one_passive = true;

			}
		}
		if(one_passive == true){
			player_pos = transform.parent.GetComponent<monster>().target.transform.position;
			GameObject effects = Instantiate(effects_ExplosionBody,new Vector3(player_pos.x,0,player_pos.z), range_collider.transform.rotation) as GameObject;
			GameObject splashs = Instantiate(splash,new Vector3(player_pos.x,0,player_pos.z), range_collider.transform.rotation) as GameObject;
			splashs.GetComponent<splash>().radius = collider_radius;
			int damage_temp = (int)((float)(transform.parent.GetComponent<monster>().damage) * splash_damage);
			if(damage_temp <= 1)
				damage_temp = 1;
			splashs.GetComponent<splash>().damage = damage_temp;
			splashs.GetComponent<splash>().player_number = 2;
			hexagon.move_end = false;
			Destroy(effects.gameObject,0.5f);
			one_passive = false;
		}
	}
}