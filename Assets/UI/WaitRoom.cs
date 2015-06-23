using UnityEngine;
using System.Collections;

public class WaitRoom : MonoBehaviour {
	int card_num;  //0: 중립 
	bool complete = false;
	Sprite original_sprite;
	bool start_ui_bool = false;
	static int select_count = 0;
	// Use this for initialization
	void Start () {
		//original_sprite = GetComponent<SpriteRenderer>().sprite;
		select_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit , Mathf.Infinity)){
			if(hit.collider.gameObject.CompareTag("waitroom_start")&& select_count == 5){
				if(Input.GetKeyDown(KeyCode.Mouse0))
				Application.LoadLevel("stage_select");

			}
			if(hit.collider.gameObject.CompareTag("waitroom_exit")){
				if(Input.GetKeyDown(KeyCode.Mouse0))
					Application.LoadLevel("ui");
				
			}
		}
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.GetComponent<Card>().select == false && complete == false){
			card_num = coll.gameObject.GetComponent<Card>().card_number;
			GetComponent<SpriteRenderer>().sprite = coll.GetComponent<SpriteRenderer>().sprite;
			coll.GetComponent<Card>().select = true;
			complete = true;
			select_count ++;
		}
	}
//	void OnTriggerExit(Collider coll){
//		card_num = 0;
//		GetComponent<SpriteRenderer>().sprite = original_sprite;
//
//	}
}
