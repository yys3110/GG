using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour {

	public bool guide_make = false;
	public bool move_bool = false;
	public GameObject guide;
	public GameObject collider;
	public Vector3 move_pos;
	public int move_count; // 이동 시 한칸 움직일 때마다 카운터를 샌다
	public int active_count =0; // 한 패턴 행동 후 카운터를 샌다. 최대 이동 후 한번의 패턴행동 가능
	public bool pattern_bool = true; // 패턴 인식 시작
	public static bool one_turn = false; //패턴 인식 후 시작되는 턴
	//패턴인식
	GameObject target; // 플레이어 유닛

	public float move_speed;
	public bool range_collider = false;
	//오브젝트 관련
	public GameObject Damage_display;
	//스킬 관련
	public GameObject skill;
	public int add_damage;
	static public int skill_active =0;
	//몬스터 정보//
	public bool ______________;
	public int monster_number; // 몇번째로 움직이는가를 판단;
	public int code_number;
	public int hp_max,hp_,damage,miss,attack_range,move_range;
	public int [] skill_number = new int[1]; // 0:없음, 1: 공격, 2: 버프
	public int monster_class; // 0 : 근접 , 1: 원거리 , 2: 능력
	public int monster_level =0; 
	public int pattern_num =0; //number 0 = 중립 ,1 = 이동 , 2 = 공격  (패턴 넘버, 움직일지 공격할지를 정함)
	public int dice_code_number =0; // 0 : 4면체 , 1 : 6면 , 2 : 8면 ,3 : 10면 , 4 : 12면체 , 5 : 20면체 (명중굴림)
	public bool die_bool = false; // 살았는지 죽었는지를 판단;
	////////////////////////
	public float target_distance; //플레이어와의 거리 
	public GameObject attack_ui; // 임시
	// Use this for initialization
	void Start () {
		hp_ = hp_max;
		monster_number = play_system.monster_max_num;
		play_system.monster_unit_num ++;
		play_system.monster_max_num ++;
	}
	
	// Update is called once per frame
	void Update () {

		if(play_system.turn == 2 && play_system.monster_num == monster_number && die_bool == true){// 죽은 몬스터
			play_system.monster_num ++;
		}
		if(play_system.turn == 2 && play_system.monster_num == monster_number && die_bool == false){ //패턴 판단 
			target = play_system.monster_target[0].transform.gameObject;
			target_distance = Vector3.Distance (transform.position , target.transform.position);
			if(pattern_bool == true){
				hex_collider.collider_complete = false;
				hexagon.move_end = false;
				monster_AI.AI_bool = true;
				if(target_distance <= attack_range*10){

					monster_AI.monster_info = transform.gameObject;
					monster_AI.AI_Battle();
					play_system.one_dice_bool = true;
					play_system.dice_active_num ++;
					pattern_bool = false;
				}
				if(target_distance >attack_range *10){ 
					monster_AI.monster_info = transform.gameObject;
					monster_AI.AI_Search();
					pattern_bool = false;
				}

			}
			if(pattern_bool == false){
				if(hex_collider.collider_complete == true)
					if(pattern_num == 1)
						move_();
				
				if(pattern_num == 2){
					attack_();
				}
				
				if(pattern_num == 3){
					skill_();
				}
				
				if(pattern_num == 4){
					wait_();
				}
			}
				
					

		}
			
		if(play_system.turn == 1){
			Ray ray = new Ray (transform.position,-transform.up);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit , 5f)&& hit.collider.gameObject.tag == "hexagon"){
				range_collider = hit.collider.GetComponent<hexagon>().range_collider;
			}
		}
		// 몬스터 HP 등 ////////////////////////////////////////////////////////////////////////
		if(hp_ <=0 && die_bool == false){
			play_system.monster_unit_num --;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			this.gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1,1,1,0.0f);
			Ray ray = new Ray(transform.position,-transform.up);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,Mathf.Infinity)&&hit.collider.gameObject.tag == "hexagon"){
				hit.collider.gameObject.GetComponent<hexagon>().hexagon_unit_bool = false;
			}
			die_bool = true;
		}

		//////////////////////////////////////////////////////////////////////////////////////
	}





	void move_(){

		if(one_turn == true){
			guide_make = true;
			move_count = move_range;
			one_turn = false;
		}

		if(guide_make == true){
			guide.GetComponent<monster_guide>().target = target;
			guide.GetComponent<monster_guide>().monster = transform.gameObject;
			Instantiate(guide,transform.position,guide.transform.rotation);
			guide_make = false;
		}
		if(move_bool == true){
			transform.localPosition = Vector3.MoveTowards(transform.position, move_pos, Time.deltaTime * move_speed);
			float distance = Vector3.Distance(transform.position, move_pos);
			hexagon.move_end = true;
			if(distance == 0){
				move_count -- ;
				if(move_count !=0){
					guide_make = true;
				}
				if(target_distance <= 10){
					move_count = 0;
				}
				Debug.Log ("move " + transform.name);
				move_bool = false;
			}
		}

		if(move_count == 0){
			active_count ++;
			pattern_bool = true;
		}
	}
	public void attack_(){
		play_system.active_dice_bool = true;
		play_system.selected_unit = transform.gameObject;
		if(play_system.dice_active_num == 3){
			if(target.GetComponent<player>().miss < damage){ // 여기서의 damage 는 명중굴림 수
				play_system.one_dice_bool = true;
				play_system.dice_active_num ++;
			}
			if(target.GetComponent<player>().miss >= damage){ // 여기서의 damage 는 명중굴림 수
				play_system.one_dice_bool = true;
				pattern_num = 4;
				GameObject dice_s = GameObject.FindWithTag ("dice");
				Destroy(dice_s);
			}
			Debug.Log ("attack " +transform.name);
		}
		if(play_system.dice_active_num == 6){
			GameObject ui_object = Instantiate(attack_ui,new Vector3(target.transform.position.x,20,
			                                                         target.transform.position.z),attack_ui.transform.rotation) as GameObject;
			target.GetComponent<player>().hp_ -= damage;
			Damage_display.GetComponent<damage>().damage_dis = damage;
			Instantiate(Damage_display,target.transform.position,Damage_display.transform.rotation);
			Destroy(ui_object,0.5f);
			pattern_num = 4;
		}

	}
	void skill_(){
		Debug.Log ("Skill " +transform.name);
		if(skill_number[0] == 0){
			Debug.Log("NO SKILL " +transform.name);
			pattern_num = 4;
		}
		else{
			GameObject ui_object = Instantiate(attack_ui,new Vector3(target.transform.position.x,20,
			target.transform.position.z),attack_ui.transform.rotation) as GameObject;
			Destroy(ui_object,0.5f);
		}
		pattern_num = 4;
	}
	void wait_(){
		play_system.dice_active_num = 0;
		hexagon.move_end = true;
		play_system.monster_num ++;
		one_turn = true;
		active_count =0;
		pattern_num = 0;
		pattern_bool = true;
		Debug.Log ("wait " +transform.name);

	}
	public void collider_range_()
	{
		Instantiate(collider,new Vector3 (transform.position.x,0,transform.position.z),collider.transform.rotation);
	}
}
