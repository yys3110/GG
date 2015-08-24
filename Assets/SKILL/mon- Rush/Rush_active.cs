using UnityEngine;
using System.Collections;

public class Rush_active : MonoBehaviour {
	GameObject target;
	public GameObject debuff;
	public int attack_num = 4;

	// Use this for initialization
	void Start () {
		target = transform.parent.GetComponent<monster>().target;
		transform.LookAt(target.transform.position);
		GameObject debuff_ = Instantiate(debuff,target.transform.position,transform.localRotation)as GameObject;
		debuff_.transform.parent = target.transform;
		debuff_.GetComponent<Rush_active_debuff>().caster = transform.parent.gameObject;
		debuff_.GetComponent<Rush_active_debuff>().commander = transform.gameObject;
		debuff_.GetComponent<Rush_active_debuff>().attack_num = attack_num;
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	public void move_(Vector3 pos){
		transform.parent.transform.position = pos;
	}
	public void wait(){
		transform.parent.GetComponent<monster>().wait_();
	}
}
