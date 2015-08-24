using UnityEngine;
using System.Collections;

public class Rush_active_debuff : MonoBehaviour {
	public GameObject caster;
	public GameObject commander;
	public int attack_num;
	public GameObject ray_pos;
	Vector3 temp_pos = Vector3.zero;
	Vector3 next_pos = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(ray_pos.transform.position,-transform.up);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
			if(hit.collider.gameObject.CompareTag("hexagon") && attack_num >0){
				temp_pos = transform.parent.transform.position;
				next_pos = hit.collider.gameObject.transform.position;
				transform.parent.transform.position = new Vector3(next_pos.x,transform.parent.transform.position.y,next_pos.z);
				commander.GetComponent<Rush_active>().move_(temp_pos);
				transform.parent.GetComponent<player>().HP_system(1,false,caster,1);
				attack_num --;
			}
		}
		else{
			transform.parent.GetComponent<player>().HP_system(1,false,caster,1);
			attack_num --;
		}
		if(attack_num <=0){
			commander.GetComponent<Rush_active>().wait();
			Destroy(gameObject);
		}
	
	}
}
