using UnityEngine;
using System.Collections;

public class SharpClaws_passive : MonoBehaviour {
	public GameObject debuff;
	public GameObject target_unit;
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		target_unit = transform.parent.GetComponent<monster>().target;
		if(play_system.turn == 2){
			if(play_system.dice_active_num == 6){
				GameObject child = Instantiate(debuff,transform.position,debuff.transform.rotation) as GameObject;
				child.transform.parent = target_unit.transform;
				child.GetComponent<SharpClaws_passive_debuff>().caster = transform.parent.transform.gameObject;
			}
		}
	}
}