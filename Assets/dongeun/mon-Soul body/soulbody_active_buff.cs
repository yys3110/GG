using UnityEngine;
using System.Collections;

public class soulbody_active_buff : MonoBehaviour {
	public int hp_max;
	public int hp;
	public GameObject caster;
	public GameObject display;
	// Use this for initialization
	void Start () {
		hp_max = transform.parent.GetComponent<monster>().hp_max ;
		caster = transform.parent.transform.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(hp_max != transform.parent.GetComponent<monster>().hp_){
			int temp_damage = hp_max - transform.parent.GetComponent<monster>().hp_;
			int temp_two_damage = (int)((float)(temp_damage) * 0.5f);
			int damage = 0;
			if(temp_two_damage <= 1)
				damage =1;
			else
				damage = temp_two_damage;

			GameObject counter_hit = transform.parent.GetComponent<monster>().Me_hit_unit;
			counter_hit.GetComponent<player>().HP_system(damage,false,caster,1);
			Instantiate(display,new Vector3(counter_hit.transform.position.x,20,counter_hit.transform.position.z),display.transform.rotation);
			hp_max = transform.parent.GetComponent<monster>().hp_;
		}
	}
}
