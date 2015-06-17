using UnityEngine;
using System.Collections;

public class soulbody_active_buff : MonoBehaviour {
	public int hp_max;
	public int hp;
	public GameObject caster;
	public GameObject display;
	public bool skill_ON = false;

	int count = 0;
	int MAX_count = 0;
	public int passive_turn = 3;
	// Use this for initialization
	void Start () {
		caster = transform.parent.transform.gameObject;
		hp_max = caster.GetComponent<monster>().hp_max;
		count = play_system.game_turn+1;
		MAX_count = count + passive_turn;
	}
	
	// Update is called once per frame
	void Update () {
		if(count == play_system.game_turn){
			count ++;
			if(count == MAX_count){
				Destroy(gameObject);
			}
			skill_ON = true;
		}
		if(skill_ON == true){
			if(hp_max != caster.GetComponent<monster>().hp_){
				int temp_damage = hp_max - caster.GetComponent<monster>().hp_;
				int temp_two_damage = ((temp_damage)/2);
				int damage = 0;
				if(temp_two_damage <= 1)
					damage = 1;
				else
					damage = temp_two_damage;
				
				GameObject counter_hit = caster.GetComponent<monster>().Me_hit_unit;
				counter_hit.GetComponent<player>().HP_system(damage,false,caster,1);
				Instantiate(display,new Vector3(counter_hit.transform.position.x,20,counter_hit.transform.position.z),display.transform.rotation);
				hp_max = caster.GetComponent<monster>().hp_;
				skill_ON = false;
			}
		}
			
	
	}
}