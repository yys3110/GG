using UnityEngine;
using System.Collections;

public class allurement_active : MonoBehaviour {
	public GameObject range_collider;
	public GameObject debuff;
	public int range = 4;

	// Use this for initialization
	void Start () {
		hexagon.move_end = false;

		GameObject range_coll = Instantiate(range_collider,transform.position - new Vector3(0,5,0),range_collider.transform.rotation) as GameObject;
		range_coll.GetComponent<range_collider>().range_ = range;
	
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray , out hit , Mathf.Infinity)){
			if(hit.collider.CompareTag("monster") && hit.collider.GetComponent<monster>().range_collider == true && Input.GetKeyDown(KeyCode.Mouse0)){
				GameObject de = Instantiate(debuff) as GameObject;
				de.transform.parent = hit.collider.transform;
				de.GetComponent<allurement_active_debuff>().caster = transform.parent.transform.gameObject;
				hexagon.move_end = true;
				Destroy(gameObject);

			}
		}
	
	}
}
