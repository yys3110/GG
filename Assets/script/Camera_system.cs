using UnityEngine;
using System.Collections;

public class Camera_system : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Mouse1)){
			if(Input.GetAxis("Mouse X") <0){
				transform.position += new Vector3(1,0,0) * speed *Time.deltaTime;
			}
			if(Input.GetAxis("Mouse X") >0){
				transform.position += new Vector3(-1,0,0) * speed * Time.deltaTime;
			}
		}
	}
}
