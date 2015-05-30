using UnityEngine;
using System.Collections;
// 흑풍(Black Wind) : 피격 된 데미지의 20%로 반격
public class BlackWind_passive : MonoBehaviour {
	public int hp_max;
	public int hp;
	public GameObject caster;
	// Use this for initialization
	void Start () {
		hp_max = transform.parent.GetComponent<player>().hp_max ;
		caster = transform.parent.transform.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(hp_max != transform.parent.GetComponent<player>().hp_){
			int temp_damage = hp_max - transform.parent.GetComponent<player>().hp_;
			int temp_two_damage = (int)((float)(temp_damage) * 0.2f);
			int damage = 0;
			if(temp_two_damage <= 1)
				damage =1;
			else
				damage = temp_two_damage;
			GameObject counter_hit = transform.parent.GetComponent<player>().Me_hit_unit;
			counter_hit.GetComponent<monster>().HP_system(damage,false,caster);



			//counter_hit.GetComponent<monster>().HP_system()
			hp_max = transform.parent.GetComponent<player>().hp_;
		}
	}
}
