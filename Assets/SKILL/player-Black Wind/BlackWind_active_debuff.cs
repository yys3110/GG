using UnityEngine;
using System.Collections;

public class BlackWind_active_debuff : MonoBehaviour {
	public GameObject caster;
	public GameObject ray_object;
	public GameObject hexagon;
	public int damage = 5;
	bool rotation_bool = false;

	// Use this for initialization
	void Start () {
		transform.position = transform.parent.transform.position;
		transform.LookAt(caster.transform.position);
		Ray ray = new Ray(ray_object.transform.position,-transform.up);
		RaycastHit hit;
		if(Physics.Raycast(ray ,out hit ,100f)){
			if(hit.collider.gameObject.tag == "hexagon"){
				hexagon =  hit.collider.gameObject;
			}
		}

		if(hexagon != null){
			transform.parent.transform.position = new Vector3(hexagon.transform.position.x,5,hexagon.transform.position.z);

		}
		else{
			rotation_bool = true;
		}
		transform.parent.transform.gameObject.GetComponent<monster>().HP_system(damage,false,caster);
		Destroy(gameObject,0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		if(rotation_bool == true){
			transform.Rotate(0,10,0);
			Ray ray = new Ray(ray_object.transform.position,-transform.up);
			RaycastHit hit;
			if(Physics.Raycast(ray ,out hit ,100f)){
				if(hit.collider.gameObject.tag == "hexagon"){
					hexagon =  hit.collider.gameObject;
					transform.parent.transform.position = new Vector3(hexagon.transform.position.x,5,hexagon.transform.position.z);
					rotation_bool = false;
				}
			}
		}
	}
}
