using UnityEngine;
using System.Collections;

public class darkFire_passive_debuff : MonoBehaviour {
	public GameObject taget;
	public int range = 10;
	public int damage = 1;
	public bool dot_damage_bool = true;
	public float distance =0;
	int count;
	public GameObject caster;
	// Use this for initialization
	void Start () {
		transform.position = transform.parent.transform.position;
		transform.position += new Vector3(0,0f,-4.5f);
		count = play_system.game_turn+1;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(count == play_system.game_turn)
		{
			count ++;
			dot_damage_bool = true;
		}
		if(dot_damage_bool == true){
			transform.parent.GetComponent<monster>().HP_system(damage,false,caster);
			dot_damage_bool = false;
		}
		distance = Vector3.Distance(transform.position,taget.transform.position);
		if(distance >= 15){
			GetComponent<Status_ailment_effect>().live = false;
		}
		
		
	}
}
