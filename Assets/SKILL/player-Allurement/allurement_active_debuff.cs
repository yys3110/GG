using UnityEngine;
using System.Collections;

public class allurement_active_debuff : MonoBehaviour {
	int order_num = 0;
	bool no_range = true;
	float del;
	bool one_font = true;
	GameObject font_;
	public GameObject range_collider;
	public GameObject caster;
	public GameObject [] monster_unit;
	public GameObject font;
	// 주사위 
	public GameObject [] dice;
	bool one_DiceRoll = true;
	bool critical = false;
	int dice_num = 0;
	int dice_OrderNum =0;
	GameObject dice_object;
	GameObject target;
	skill_dice dice_component;
	// Use this for initialization
	void Start () {
		//hexagon.move_end = false;
		transform.localPosition = new Vector3(0,0,-0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(order_num == 0){
			if(del >= 0.15f)
				order_num = 1;
		}
		if(order_num == 1){
			hexagon.move_end = true;
			int attack_range = transform.parent.GetComponent<monster>().attack_range;
			hexagon.move_end = false;
			GameObject range_coll = Instantiate(range_collider,transform.parent.transform.position - new Vector3(0,5,0),range_collider.transform.rotation) as GameObject;
			range_coll.GetComponent<range_collider>().range_ = attack_range;
			monster_unit = GameObject.FindGameObjectsWithTag("monster");
			order_num = 2;
		}
		if(order_num == 2 && del >= 0.25f){
			for(int i =0; i< monster_unit.Length; i++){
				if(monster_unit[i].GetComponent<monster>().range_collider == true && monster_unit[i] != transform.parent.transform.gameObject ){
					no_range = false;
					Debug.Log(monster_unit[i]);
				}
			}
			order_num = 3;
		}
		if(order_num == 3){
			if(no_range == true){
				if(one_font == true){
					font_ = Instantiate(font) as GameObject;
					font_.GetComponent<TextMesh>().text = "공격 범위 안에 적이 없어\n 자신을 공격 합니다.";
				}
				one_font = false;
				if(del >= 0.5f && Input.GetKeyDown(KeyCode.Mouse0)){
				Destroy(font_.gameObject);
				order_num = 4;
				}
			}
			if(no_range == false){
				if(one_font == true){
					font_ = Instantiate(font) as GameObject;
					font_.GetComponent<TextMesh>().text = "범위 안의 적을 클릭 하여\n 공격 하십시오.";
				}
				one_font = false;
				if(del >= 0.5f && Input.GetKeyDown(KeyCode.Mouse0)){
					Destroy(font_.gameObject);
					order_num = 4;
				}
			}
			font_.transform.position = Camera.main.transform.position + new Vector3(0,-35,35);
		}
		if(order_num == 4){
				
			if(no_range == true){
				if(dice_OrderNum ==0){
					Camera.main.GetComponent<play_system>().dice_systemOn();
					dice_object =  Instantiate(dice[5],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
					dice_component = dice_object.GetComponent<skill_dice>();
					dice_OrderNum =1;
				}

				if(dice_OrderNum ==1){
					if(dice_component.dice_roll == false && play_system.dice_active_num == 1){
						dice_num = dice_component.dice_num;
						dice_OrderNum = 2;
					}
				}
				if(dice_OrderNum == 2){
					int miss = transform.parent.GetComponent<monster>().miss;
					if(miss < dice_num){
						dice_OrderNum = 3;
						if(18<= dice_num){
							critical = true;
						}
					}
					if(miss >= dice_num){
						hexagon.move_end = true;
						caster.GetComponent<player>().wait_();
						play_system.dice_active_num = 0;
						Destroy(gameObject);
					}
				}
				if(dice_OrderNum == 3){
					int parent_diceNum = transform.parent.GetComponent<monster>().dice_code_number;
					dice_object =  Instantiate(dice[parent_diceNum],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
					dice_component = dice_object.GetComponent<skill_dice>();
					dice_OrderNum = 4;
				}
				if(dice_OrderNum == 4){
					if(dice_component.dice_roll == false && play_system.dice_active_num == 2){
						dice_num = dice_component.dice_num;
						dice_OrderNum = 5;
					}
				}
				if(dice_OrderNum == 5){
					transform.parent.GetComponent<monster>().HP_system(dice_num, critical,null,1);
					hexagon.move_end = true;
					caster.GetComponent<player>().wait_();
					play_system.dice_active_num = 0;
					Destroy(gameObject);
				}
			}
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if(no_range == false){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(ray ,out hit , Mathf.Infinity)){
					if(hit.collider.CompareTag("monster") && hit.collider.GetComponent<monster>().range_collider == true){
						if(Input.GetKeyDown(KeyCode.Mouse0)){
							target = hit.collider.gameObject;
							dice_OrderNum = 1;
						}
					}
				}
				if(dice_OrderNum ==1){
					Camera.main.GetComponent<play_system>().dice_systemOn();
					dice_object =  Instantiate(dice[5],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
					dice_component = dice_object.GetComponent<skill_dice>();
					dice_OrderNum =2;
				}
				if(dice_OrderNum ==2){
					if(dice_component.dice_roll == false && play_system.dice_active_num == 1){
						dice_num = dice_component.dice_num;
						dice_OrderNum = 3;
					}
				}
				if(dice_OrderNum == 3){
					int miss = target.GetComponent<monster>().miss;
					if(miss < dice_num){
						dice_OrderNum = 4;
						if(18<= dice_num){
							critical = true;
						}
					}
					if(miss >= dice_num){
						hexagon.move_end = true;
						caster.GetComponent<player>().wait_();
						play_system.dice_active_num = 0;
						Destroy(gameObject);
					}
				}
				if(dice_OrderNum == 4){
					int parent_diceNum = target.GetComponent<monster>().dice_code_number;
					dice_object =  Instantiate(dice[parent_diceNum],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
					dice_component = dice_object.GetComponent<skill_dice>();
					dice_OrderNum = 5;
				}
				if(dice_OrderNum == 5){
					if(dice_component.dice_roll == false && play_system.dice_active_num == 2){
						dice_num = dice_component.dice_num;
						dice_OrderNum = 6;
					}
				}
				if(dice_OrderNum == 6){
					target.GetComponent<monster>().HP_system(dice_num, critical,null,1);
					hexagon.move_end = true;
					caster.GetComponent<player>().wait_();
					play_system.dice_active_num = 0;
					Destroy(gameObject);
				}
			}
		}
	}
}
