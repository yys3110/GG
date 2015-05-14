using UnityEngine;
using System.Collections;
//유수 스킬
public class skill1 : MonoBehaviour {
	public GameObject camera_object;
	public Camera mainCam;
	public float rotateY;
	public GameObject range;
	// Use this for initialization
	void Start () {
		camera_object = GameObject.FindWithTag("MainCamera");
		mainCam = camera_object.GetComponent<Camera>();
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
			if(hit.collider.gameObject.tag == "hexagon")
			{
				
				transform.LookAt(hit.collider.gameObject.transform.position);
				transform.rotation = new Quaternion(0,transform.rotation.y,0,transform.rotation.w);
				//transform.eulerAngles = new Vector3(0,transform.rotation.y,0);
			range.active = false;
				rotateY = transform.eulerAngles.y;
				if((rotateY >= 30 && rotateY <= 34) ||
				  (rotateY >= 88 && rotateY <= 91) ||
				   (rotateY >= 145 && rotateY <= 148) ||
				   (rotateY >= 210 && rotateY <= 214) || 
				   (rotateY >= 267 && rotateY <= 271) ||
				   (rotateY >= 325 && rotateY <= 328))
				{
					Debug.Log(rotateY);
				range.active = true;
					hexagon.move_end = false;
				}
				else{
					hexagon.move_end = true;
				}
			}
		}
	}
}