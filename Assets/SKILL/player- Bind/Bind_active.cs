using UnityEngine;
using System.Collections;

public class Bind_active : MonoBehaviour {

	public GameObject [] monster_list;
	public GameObject range_collider;
	public GameObject debuff;
	bool one_collider = true;
	bool one_count = true;
	int click_count =0;
	float del =0;

	// Use this for initialization
	void Start () {
		hexagon.move_end = false;
		monster_list = GameObject.FindGameObjectsWithTag("monster");

	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(one_collider == true){

			GameObject range = Instantiate(range_collider,transform.position+ new Vector3(0,-5,0),transform.rotation) as GameObject;
			range.GetComponent<range_collider>().range_ = 3;
			one_collider = false;
		}
		if(del >=0.2f && one_count == true){
			for(int i =0; i< monster_list.Length; i++){
				if(monster_list[i].GetComponent<monster>().range_collider == true){
					click_count ++;
					if(click_count >2)
						click_count = 2;
				}
			}
			one_count = false;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit , Mathf.Infinity)){
			if(hit.collider.CompareTag("monster") && Input.GetKeyDown(KeyCode.Mouse0)){
				if(hit.collider.GetComponent<monster>().range_collider == true && hit.collider.GetComponentInChildren<Bind_active_debuff>() == false){
					GameObject debuff_ = Instantiate(debuff) as GameObject;
					debuff_.transform.parent = hit.collider.gameObject.transform;
					click_count --;
				}
			}
		}
		if(one_count == false && click_count <=0){
			hexagon.move_end = true;
			transform.parent.GetComponent<player>().wait_();
			Destroy(gameObject);
		}
	}
}
