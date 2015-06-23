using UnityEngine;
using System.Collections;

public class hexagon : MonoBehaviour {

	public bool guide_bool = false; 
	public bool collider_bool = false;
	public bool mouse_over_bool = false;
	public bool range_collider = false;  // range_collider 가 필드에 펼쳐졌을때 그 위에 유닛이 있는가
	public bool hexagon_unit_bool = false; // hexagon 위에 유닛이 있는가를 판별, 가이드가 판별을 하여 지나갈지 말지를 판단
	public static bool move_end = false; // move_end 가 true 일 경우 hexagon의 색갈과 정보값 초기화 
	public int hexagon_type;


	//public bool move_ = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.mouse_over == false)
		{
			guide_bool = false;
			collider_bool = false;
			mouse_over_bool = false;
		}
		if(move_end == true)
		{
			range_collider = false;
			GetComponent<Renderer>().material.color = new Color (1,1,1,1);
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "hex_collider")
		{
		GetComponent<Renderer>().material.color = new Color(0.5f,0.5f,0.5f,0.5f);
		range_collider = true;
		}
		if(coll.gameObject.tag == "player"){
			hexagon_unit_bool = true;
		}
		if(coll.gameObject.tag == "monster"){
			hexagon_unit_bool = true;
		}
	}
	void OnTriggerExit(Collider coll)
	{
		if(coll.gameObject.tag == "hex_collider")
		{
			//renderer.material.color = new Color (1,1,1,1);
		}
		if(coll.gameObject.tag == "player"){
			hexagon_unit_bool = false;
		}
		if(coll.gameObject.tag == "monster"){
			hexagon_unit_bool = false;
		}
	}
}
