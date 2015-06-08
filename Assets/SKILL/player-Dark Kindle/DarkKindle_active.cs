using UnityEngine;
using System.Collections;
// 암휘(Dark Kindle) active :4칸 내의 적 한명에게 10의 데미지(5턴)+1턴 행동불가
public class DarkKindle_active : MonoBehaviour {
	public GameObject range_collider;
	public GameObject debuff;
	public int range = 4;
	public int skill_damage = 10;
	public GameObject caster;


	// Use this for initialization
	void Start () {
		caster = play_system.playing_uint;
		hexagon.move_end = false;
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
		range_collider.GetComponent<range_collider>().range_ = range;
		Instantiate(range_collider,new Vector3(transform.position.x,0,transform.position.z),range_collider.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit , Mathf.Infinity)){
			if(hit.collider.gameObject.tag == "monster" && hit.collider.GetComponent<monster>().range_collider == true){
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					hit.collider.GetComponent<monster>().HP_system(10,false,caster);
					Vector3 hit_pos = hit.collider.transform.position;
					GameObject mon_child = Instantiate(debuff,hit_pos,transform.rotation) as GameObject;
					mon_child.transform.parent = hit.collider.transform;
					mon_child.transform.localScale += new Vector3(0.25f,0.25f,0.25f);
					transform.parent.GetComponent<player>().wait_();
					Destroy(gameObject);
				}
			}
		}
		if(transform.parent.GetComponent<player>().chance_turn == false){
			Destroy(gameObject);
		}
	}
}
