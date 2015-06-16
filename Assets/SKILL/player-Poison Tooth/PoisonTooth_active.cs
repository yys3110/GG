using UnityEngine;
using System.Collections;
//독아(Poison Tooth) : 4칸 내의 지형 한칸을 오염시켜 이동불가로 만듬
public class PoisonTooth_active : MonoBehaviour {
	public GameObject range_collider;
	public GameObject active_object;
	public int range;
	Vector3 hit_position;

	// Use this for initialization
	void Start () {
		hexagon.move_end = false;
		//range_collider.GetComponent<range_collider>().range_ = range;
		GameObject range_coll = Instantiate(range_collider,new Vector3(transform.parent.transform.position.x,0,transform.parent.transform.position.z)
		                                    ,range_collider.transform.rotation)as GameObject ;
		range_coll.GetComponent<range_collider>().range_ = range;
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
			if(hit.collider.tag == "hexagon" && hit.collider.GetComponent<hexagon>().range_collider == true ){
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					hit_position = hit.collider.transform.position;
					GameObject object_ = Instantiate(active_object,hit_position,active_object.transform.rotation) as GameObject;
					object_.transform.parent = hit.collider.transform;
					hexagon.move_end = true;
					transform.parent.GetComponent<player>().wait_();
					Destroy(gameObject);
				}
			}
		}
	
	}
}
