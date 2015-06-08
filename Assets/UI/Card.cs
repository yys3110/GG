using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
	public Vector3 original_pos;
	public bool move_bool = false;
	public int card_number;
	public bool select = false;
	bool one_move = true;

	// Use this for initialization
	void Start () {
		original_pos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			move_bool = false;
			transform.localPosition = original_pos;
		}
		if(move_bool == true){
			Vector2 mouse_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//transform.position = mouse_;
			transform.position = new Vector3(mouse_.x,mouse_.y,transform.position.z);
		}
		if(select == true && one_move == true){
			GetComponent<BoxCollider>().enabled = false;
			GetComponent<Renderer>().material.color = new Color(1,1,1,0.3f);
			transform.localPosition = original_pos;
			one_move = false;
		}
	
	}
	void OnMouseOver(){
		if(Input.GetKeyDown(KeyCode.Mouse0) && select == false){
			move_bool = true;

		}
	}
}
