using UnityEngine;
using System.Collections;

public class SharpClaws_passive : MonoBehaviour {
	public int turn = 3;
	public int damage = 3;
	public GameObject debuff;
	int hp_max = 0;
	// Use this for initialization
	void Start () {
		hp_max = transform.parent.GetComponent<monster>().hp_max;
	}
	// Update is called once per frame
	void Update () {
		if(hp_max != transform.parent.GetComponent<monster>().hp_){
			GameObject hit_unit = transform.parent.GetComponent<monster>().Me_hit_unit;
			GameObject debuff_ = Instantiate(debuff,hit_unit.transform.position,hit_unit.transform.rotation) as GameObject;
			debuff_.GetComponent<SharpClaws_passive_debuff>().caster = transform.parent.transform.gameObject;
			debuff_.transform.parent = hit_unit.transform;
			hp_max = transform.parent.GetComponent<monster>().hp_;
		}


	}
}