using UnityEngine;
using System.Collections;

public class Authority_active : MonoBehaviour {
	//권위 
	//사거리 내의 아군 재조작 가능(3턴)
	public Camera maincamera;
	public GameObject collider;
	public int range_collider;
	GameObject coll;


	// Use this for initialization
	void Start () {
		player.skill_cast = true;
		hexagon.move_end = false;
		collider.GetComponent<range_collider>().range_ = range_collider;
		coll = Instantiate(collider,new Vector3(transform.parent.position.x,0,transform.parent.position.z),collider.transform.rotation) as GameObject;
		maincamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit , Mathf.Infinity)){
			if(hit.collider.gameObject.tag == "player"){
				if(Input.GetKeyDown(KeyCode.Mouse0) && hex_collider.collider_complete == true && hit.collider.GetComponent<player>().range_collider == true){
					if(hit.collider.GetComponent<player>().chance_turn == false){
						play_system.player_num --;
						hit.collider.GetComponent<player>().chance_turn = true;
						transform.parent.GetComponent<player>().wait_();
						hexagon.move_end = true;
						player.skill_cast = false;
						Debug.Log(hit.collider.gameObject.name + "unit active skill");
						Destroy(gameObject);
					}
				}
			}
		}
	}
}
