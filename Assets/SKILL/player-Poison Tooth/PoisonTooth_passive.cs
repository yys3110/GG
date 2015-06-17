using UnityEngine;
using System.Collections;
//독아(Poison Tooth) : 타격한 적에게 3턴간 매턴 1의 데미지
public class PoisonTooth_passive : MonoBehaviour {
	public int damage =1;
	public GameObject debuff_object;
	public GameObject caster;
	// Use this for initialization
	void Start () {
		caster = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.dice_active_num == 6 && transform.parent.GetComponent<player>().active_num ==2){
			Debug.Log("poisonTooth passive attack");
			GameObject target = transform.parent.GetComponent<player>().monster_unit;
			GameObject debuff = Instantiate(debuff_object) as GameObject;
			debuff.GetComponent<PoisonTooth_passive_debuff>().caster = caster;
			debuff.GetComponent<PoisonTooth_passive_debuff>().damage = damage;
			debuff.transform.parent = target.transform;
		}
	
	}
}
