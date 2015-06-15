using UnityEngine;
using System.Collections;
//폭신 엑티브
//사망을 대가로 2칸 내의 모든 적에게 1의 고정 피해
public class ExplosionBody_active : MonoBehaviour {
	public int range;
	float del = 0;
	public GameObject effects;
	bool one_skill = true;
	public GameObject caster;
	public GameObject dis_font;
	// Use this for initialization
	void Start () {
		caster = play_system.playing_uint;
		transform.position = transform.parent.transform.position;
		GetComponent<SphereCollider>().radius = range;
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(del >= 0.2f && one_skill == true){
			GameObject skill_effects = Instantiate(effects,transform.localPosition,transform.rotation) as GameObject;
			skill_effects.transform.position = transform.parent.transform.position;
			Destroy(skill_effects,1f);
			transform.parent.GetComponent<monster>().HP_system(999,false,null,0);
			Instantiate (dis_font,new Vector3(transform.position.x,20,transform.position.z),dis_font.transform.rotation);
			one_skill = false;

		}
	}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "player"){
			coll.GetComponent<player>().HP_system(1,false,caster,0);

		}

	}
}
