using UnityEngine;
using System.Collections;
//암화(Dark Fire): 3칸 내의 적 한명에게 2턴간 2, 총 4의 데미지(2턴)
public class DarkFire_active : MonoBehaviour {
	public GameObject range_collider;
	public GameObject debuff;
	public int range = 3;
	public GameObject caster;
	// Use this for initialization
	void Start () {
		hexagon.move_end = false;
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
		range_collider.GetComponent<range_collider>().range_ = range;
		Instantiate(range_collider,new Vector3(transform.position.x,0,transform.position.z),range_collider.transform.rotation);
		caster = play_system.playing_uint;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit , Mathf.Infinity)){
			if(hit.collider.gameObject.tag == "monster" && hit.collider.GetComponent<monster>().range_collider == true){
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					Vector3 hit_pos = hit.collider.transform.position;
					GameObject mon_child = Instantiate(debuff,hit_pos,debuff.transform.rotation) as GameObject;
					mon_child.transform.parent = hit.collider.transform;
					mon_child.GetComponent<DarkFire_active_debuff>().caster = caster;
					transform.parent.GetComponent<player>().wait_();
					Destroy(gameObject);
				}
			}
		}
	}
}
