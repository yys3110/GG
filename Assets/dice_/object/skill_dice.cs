﻿using UnityEngine;
using System.Collections;

public class skill_dice : MonoBehaviour {
	public bool dice_roll = false;
	public int dice_number; // 몇 면체의 주사위 인가
	public int dice_num;
	public int collider_num;
	public Vector3 velocity_dice;
	public float velocityd;
	public bool camera_move_bool = false;
	public GameObject dice_camera;
	public float del;
	public bool skill_caster_reg_bool = true;
	//스킬 관련
	public GameObject skill_caster;
	Rect go_rect;
	public int type = 0; // type 0 일 경우 누가 던지는가를 판단을 play_system.turn 에서 하고 type 1 이상 일 경우 지정 한 대로 판단
	// Use this for initialization
	void Start () {
		skill_caster_reg_bool = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(dice_roll == true){
			del += Time.deltaTime;
			dice_num = (dice_number+1) - collider_num;
			velocity_dice = this.GetComponent<Rigidbody>().velocity;
			velocityd = this.GetComponent<Rigidbody>().velocity.magnitude;
			//if((velocity_dice.x ==0 && velocity_dice.y ==0 && velocity_dice.z ==0)|| del>=5){
			if(velocityd <= 0.0f){
				play_system.play_dice_num = dice_num;
				if(type == 0){
					if(play_system.turn == 1){
						camera_move_bool = true;
					}
					if(play_system.turn == 2){
						dice_camera = GameObject.FindWithTag ("ui_camera");
						dice_camera.transform.localPosition = new Vector3(0,8.92f,-9.18f);
						transform.localPosition = new Vector3(0.06001282f,1,-4.0f);
						go_rect = new Rect (0,0,0,0);
						if(skill_caster_reg_bool == true)
						skill_caster.transform.GetComponent<monster>().temp_skill_dice_num = dice_num;
						monster.skill_active++;
						//Destroy(gameObject);
					}
				}
				if(type == 1){
					monster.skill_active ++;
				}
				del =0;
				dice_roll = false;
			}
		}
		if(camera_move_bool == true){
			dice_camera = GameObject.FindWithTag ("ui_camera");
			if(dice_number == 0)
				transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x,240,transform.localEulerAngles.z);
			if(dice_camera != null)
				dice_camera.transform.position = Vector3.MoveTowards
					(dice_camera.transform.position,new Vector3(this.transform.position.x,4,this.transform.position.z-3),Time.deltaTime*10);
			float distance = Vector3.Distance(new Vector3(this.transform.position.x,4,this.transform.position.z-3),dice_camera.transform.position);
			if(distance == 0){
				go_rect = new Rect (300,200,100,100);
				camera_move_bool = false;
			}
		}
		
		/*if(play_system.turn == 2 && play_system.monster_one_dice_bool == true){
			OnMouseDown();
			play_system.monster_one_dice_bool = false;
			Debug.Log("monster dice roll");
		}*/
		
	}
	public void OnMouseDown(){
		if(dice_roll == false){
			this.GetComponent<Rigidbody>().velocity += new Vector3 (0,10,5);
			int random_y = Random.Range(-100,100);
			int random_x= Random.Range(-100,100);
			this.GetComponent<Rigidbody>().AddTorque(new Vector3(random_x,random_y,0));
			dice_roll = true;
		}
		
	}
	
	void OnGUI(){
		if(play_system.turn == 1){
			if(GUI.RepeatButton(go_rect,"GO")){
				dice_camera.transform.localPosition = new Vector3(0,8.92f,-9.18f);
				transform.localPosition = new Vector3(0.06001282f,1,-4.0f);
				play_system.dice_active_num ++;
				go_rect = new Rect (0,0,0,0);
				Destroy(gameObject);
			}
		}
	}
}
