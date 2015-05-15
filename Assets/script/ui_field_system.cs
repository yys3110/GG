using UnityEngine;
using System.Collections;

public class ui_field_system : MonoBehaviour {
	public Camera ui_camera;
	public GameObject unit_info; //플레이어 유닛이 자신의 정보를 보내어 여기로 저장;
	GameObject over_mouse_g;
	public  bool ui_cancel_bool = true;
	public  bool ui_move_bool = true;
	public GameObject [] ui_a_m; // attack, move 오브젝트
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(ui_move_bool == true){
			ui_a_m[0].GetComponent<Renderer>().material.color = new Color(1,1,1,1f);
		}
		if(ui_move_bool == false){
			ui_a_m[0].GetComponent<Renderer>().material.color = new Color(1,1,1,0.25f);
		}
		if(ui_cancel_bool == true){
			ui_a_m[1].GetComponent<Renderer>().material.color = new Color(1,1,1,1f);
		}
		if(ui_cancel_bool == false){
			ui_a_m[1].GetComponent<Renderer>().material.color = new Color(1,1,1,0.25f);
		}
		Ray ray = ui_camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if(over_mouse_g != null)
		over_mouse_g.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
		if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
			if(hit.collider.gameObject.tag == "ui_attack"){
				over_mouse_g = hit.collider.gameObject;
				over_mouse_g.GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					unit_info.GetComponent<player>().active_num = 2;
					unit_info.SendMessage("OnField_ui");
					transform.gameObject.active = false;
				}
			}
			if(hit.collider.gameObject.tag == "ui_move" && ui_move_bool == true){
				over_mouse_g = hit.collider.gameObject;
				over_mouse_g.GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					unit_info.GetComponent<player>().active_num = 1;
					unit_info.SendMessage("OnField_ui");
					transform.gameObject.active = false;
				}
			}
			if(hit.collider.gameObject.tag == "ui_skill" && ui_move_bool == true){
				over_mouse_g = hit.collider.gameObject;
				over_mouse_g.GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					unit_info.GetComponent<player>().active_num = 3;
					transform.gameObject.active = false;
				}
			}
			if(hit.collider.gameObject.tag == "ui_wait"){
				over_mouse_g = hit.collider.gameObject;
				over_mouse_g.GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					unit_info.GetComponent<player>().active_num = 4;
					transform.gameObject.active = false;
				}
			}
			if(hit.collider.gameObject.tag == "ui_cancel" && ui_cancel_bool == true){
				over_mouse_g = hit.collider.gameObject;
				over_mouse_g.GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					unit_info.GetComponent<player>().active_num = 5;
					transform.gameObject.active = false;
				}
			}
		}
	}

	void reset_bool(){
		ui_cancel_bool = true;
		ui_move_bool = true;
	}
}
