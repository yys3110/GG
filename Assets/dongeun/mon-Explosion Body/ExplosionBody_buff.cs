using UnityEngine;
using System.Collections;
//폭신 페시브
public class ExplosionBody_buff : MonoBehaviour {
	//public GameObject camera_object;//클릭으로 시전해봄
	//public Camera mainCam;
	public Vector3 player_pos;
	// Use this for initialization
	void Start () {
		/*camera_object = GameObject.FindWithTag("MainCamera");
		mainCam = camera_object.GetComponent<Camera>();*/
	}
	
	// Update is called once per frame
	void Update () {
		// 클릭으로 시전해봄
		/*Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
			if(Input.GetKeyDown(KeyCode.Mouse0)){
			if(hit.collider.gameObject.tag == "player")
			{
					monster_pos = hit.collider.transform.position;
					Debug.Log(monster_pos);
					transform.position = monster_pos;

			}

		}
	}*/
		if(play_system.turn == 2){
			Debug.Log("들어왔다 꺄~");
			gameObject.SetActive(true);
			player_pos = transform.parent.GetComponent<monster>().target.transform.position;
			Debug.Log(player_pos);
			transform.position = player_pos;
		}
}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "player"){
			coll.GetComponent<player>().hp_ --;
			gameObject.SetActive(false);
		}
	}
}