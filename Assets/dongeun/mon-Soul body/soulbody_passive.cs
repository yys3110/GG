using UnityEngine;
using System.Collections;

public class soulbody_passive : MonoBehaviour {
	public GameObject target_unit;
	public GameObject debuff;
	public bool passive_On = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		target_unit = transform.parent.GetComponent<monster>().target;
		
		if(play_system.turn == 2){
			if(play_system.dice_active_num == 1){
				if(passive_On == false){
					GameObject child = Instantiate(debuff,transform.position,debuff.transform.rotation) as GameObject;
					Debug.Log("죽어라!");
					child.transform.parent = target_unit.transform;
					child.GetComponent<soulballs_passive_debuff>().caster = transform.parent.transform.gameObject;
					passive_On = true;
					
				}
			}
		}
		if(play_system.turn == 1){
			passive_On = false;
		}
	}
}
