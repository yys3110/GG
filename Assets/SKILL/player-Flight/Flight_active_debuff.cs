using UnityEngine;
using System.Collections;

public class Flight_active_debuff : MonoBehaviour {
	public Vector3 rotate_;
	public GameObject caster;
	public GameObject player_pos;
	public GameObject monster_pos;
	bool move_bool = true;
	float del= 0;


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(move_bool == true){
			transform.localEulerAngles = rotate_;
			Ray ray = new Ray(player_pos.transform.position,-transform.up);
			RaycastHit hit;
			if(Physics.Raycast(ray , out hit , Mathf.Infinity)){
				if(hit.collider.gameObject.CompareTag("hexagon")){
					Vector3 hit_pos = hit.collider.transform.position;
					caster.transform.position = new Vector3(hit_pos.x,5,hit_pos.z);
				}
			}
			Ray ray_2 = new Ray (monster_pos.transform.position,-transform.up);
			RaycastHit hit_2;
			if(Physics.Raycast(ray_2,out hit_2 , Mathf.Infinity)){
				if(hit_2.collider.gameObject.CompareTag("hexagon") ){
					int hex = hit_2.collider.GetComponent<hexagon>().hexagon_type;
					if(hit_2.collider.GetComponent<hexagon>().hexagon_unit_bool == false && !(hex == 0  || hex == 1 || hex == 4 || hex == 5)){
						Vector3 hit_pos = hit_2.collider.transform.position;
						transform.parent.transform.position = new Vector3(hit_pos.x,5,hit_pos.z);
						transform.parent.GetComponent<monster>().HP_system(1,false,caster,0);
					}
					else{
						move_bool = false;
						transform.parent.GetComponent<monster>().HP_system(1,false,caster,0);
						caster.GetComponent<player>().wait_();
						Destroy(gameObject);
					}
				}
			}
			if(del >=1f){
				move_bool = false;
				transform.parent.GetComponent<monster>().HP_system(1,false,caster,0);
				caster.GetComponent<player>().wait_();
				Destroy(gameObject);
			}
		}
	}
}
