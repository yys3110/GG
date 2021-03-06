﻿using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	GameObject hit_collider_left;
	GameObject hit_collider_right;
	public GameObject [] ui_;
	public GameObject [] ui_pos;
	public int ui_num =0;
	bool ui_move = true;
	public float speed;
	GameObject color_object;
	GameObject mouse_OverObject;
	public Texture [] left_right_ui;
	public Texture2D cursor;
	// Use this for initialization
	void Start () {
		//Screen.SetResolution(800,600,false);
		Cursor.SetCursor(cursor,Vector2.zero,CursorMode.Auto);
		//Screen.SetResolution(1280,720,false);
	}
	
	// Update is called once per frame
	void Update () {
		Ray color_ray = new Ray(transform.position,transform.forward);
		RaycastHit color_hit;
		if(Physics.Raycast(color_ray, out color_hit ,10f)){
			if(color_object != null){
				color_object.GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
			}
			color_object = color_hit.transform.gameObject;
			color_object.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
		}
		if(hit_collider_left != null)
		{
			hit_collider_left.GetComponent<Renderer>().material.mainTexture = left_right_ui[0];
		}
		if(hit_collider_right != null)
		{
			hit_collider_right.GetComponent<Renderer>().material.mainTexture = left_right_ui[2];
		}
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit , Mathf.Infinity))
		{
			if(hit.collider.gameObject.tag == "UI_left")
			{	
				hit_collider_left = hit.collider.gameObject;
				//hit_collider.GetComponent<Renderer>().material.color = Color.black;
				hit_collider_left.GetComponent<Renderer>().material.mainTexture = left_right_ui[1];
				if(Input.GetKeyDown(KeyCode.Mouse0))
				{
					ui_move = true;
					ui_num ++;
					if(ui_num >= 5)
						ui_num = 0;
				}
			}
			if(hit.collider.gameObject.tag == "UI_right")
			{
				hit_collider_right = hit.collider.gameObject;
				//hit_collider.GetComponent<Renderer>().material.color = Color.black;
				hit_collider_right.GetComponent<Renderer>().material.mainTexture = left_right_ui[3];
				if(Input.GetKeyDown(KeyCode.Mouse0))
				{
					ui_move = true;
					ui_num --;
				}
			}
			if(hit.collider.gameObject.CompareTag("new")){
				mouse_OverObject = hit.collider.gameObject;
				mouse_OverObject.GetComponent<Renderer>().material.color = new Color(0.8f,0.8f,0.8f,0.75f);
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					Application.LoadLevel("waitroom");
				}
			}
			if(hit.collider.gameObject.CompareTag("exit")){
				mouse_OverObject = hit.collider.gameObject;
				mouse_OverObject.GetComponent<Renderer>().material.color = new Color(0.8f,0.8f,0.8f,0.75f);
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					Application.Quit();
				}
			}
		}
		if(ui_move == true)
		{
			for(int i = 0; i<5; i++)
			{
				ui_num ++;
				if(ui_num >4)
				{
					ui_num =0;
				}
				if(ui_num <0)
				{
					ui_num = 4;
				}
				ui_[i].transform.localPosition = Vector3.MoveTowards
					(ui_[i].transform.position,ui_pos[ui_num].transform.position,
					 Time.deltaTime * speed);
			}
		}
	}
}
