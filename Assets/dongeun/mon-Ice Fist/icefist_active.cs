using UnityEngine;
using System.Collections;
//4칸 안에 한명에게 고정데미지 와 1턴간 행동불가 4칸은 몬스터의 게임오프젝트에 있는skill_range를 40으로 하고 사용
public class icefist_active : MonoBehaviour {
	public GameObject target_unit;
	public GameObject debuff;
	public int turn_cooltime; // 스킬 쿨타임
	public int ice; // 고정데미지

	// Use this for initialization
	void Start () {
		target_unit = transform.parent.GetComponent<monster>().target;
	}
	
	// Update is called once per frame
	void Update () {
		target_unit.GetComponent<player>().HP_system(ice,false,transform.parent.gameObject,1);

		GameObject child = Instantiate(debuff,transform.position,debuff.transform.rotation) as GameObject;
		child.transform.parent = target_unit.transform;
		child.GetComponent<icefist_active_debuff>().caster = transform.parent.transform.gameObject;
		Destroy(gameObject);
	}
}
