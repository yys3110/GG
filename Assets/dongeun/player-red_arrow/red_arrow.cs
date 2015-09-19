using UnityEngine;
using System.Collections;
//적시 스킬
public class red_arrow : MonoBehaviour {
	public int damage;
	
	public GameObject camera_object;
	public Camera mainCam;
	public float rotateY;
	public GameObject range;
	public int turn_cooltime;
	public bool skill_on = false;
	public bool one_bool = true;
	// Use this for initialization
	void Start () {
		camera_object = GameObject.FindWithTag("MainCamera");
		mainCam = camera_object.GetComponent<Camera>();
		
	}
	
	// Update is called once per frame
	void Update () {
		// 액티브스킬
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
			if(hit.collider.gameObject.tag == "hexagon")
			{
				
				transform.LookAt(hit.collider.gameObject.transform.position);
				transform.rotation = new Quaternion(0,transform.rotation.y,0,transform.rotation.w);
				//transform.eulerAngles = new Vector3(0,transform.rotation.y,0);
				range.SetActive(false);
				rotateY = transform.eulerAngles.y;
				if((rotateY >= 30 && rotateY <= 34) ||
				   (rotateY >= 88 && rotateY <= 91) ||
				   (rotateY >= 145 && rotateY <= 148) ||
				   (rotateY >= 210 && rotateY <= 214) || 
				   (rotateY >= 267 && rotateY <= 271) ||
				   (rotateY >= 325 && rotateY <= 328))
				{
					skill_on = true;
					range.SetActive(true);
					hexagon.move_end = false;
					
				}
				else{
					skill_on = false;
					hexagon.move_end = true;
					
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Mouse0)&&one_bool == true && skill_on == true)
		{
			range.SetActive(false);
			hexagon.move_end = true;
			one_bool = false;
			transform.parent.GetComponent<player>().wait_();
		}
		// 액티브스킬 끝
	}
}
