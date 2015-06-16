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
	public bool one_move_pattern = true; //패턴 인식 후 move 움직임이 true 가 되어 움직일수 있게 해 준다 
	public bool one_collider_create = true; // 패턴 인식 후 range_collider 를 생성 해주는 bool 이 true 가 된다, attack 패턴에 쓰고있다.
	//패턴인식
	public GameObject target; // 플레이어 유닛
	public float move_speed;
	public bool range_collider = false;
	//오브젝트 관련
	public GameObject [] Damage_display;

	//스킬 관련
	public GameObject skill;
	public float skill_range;
	public bool skill_bool = false; // 스킬이 있는가 없는가;
	public bool now_skill = false;
	public GameObject Me_hit_unit;
	//public int add_damage;
	static public int skill_active =0;
	public bool one_skill_bool = true;
	public int temp_skill_dice_num = 0;
	// 추가 데미지 및 방어 관련
	public int add_damage =0;
	public int defense = 0;
	public bool criticalHit_bool = false;
	//몬스터 정보//
	public bool ______________;
	public int monster_number; // 몇번째로 움직이는가를 판단;
	public int code_number;
	public int hp_max,hp_,damage,miss,attack_range,move_range;
	public int monster_class; // 0 : 근접 , 1: 원거리 , 2: 능력
	public int monster_level =0; 
	public int pattern_num =0; //number 0 = 중립 ,1 = 이동 , 2 = 공격  (패턴 넘버, 움직일지 공격할지를 정함)
	public int dice_code_number =0; // 0 : 4면체 , 1 : 6면 , 2 : 8면 ,3 : 10면 , 4 : 12면체 , 5 : 20면체 (명중굴림)
	public bool die_bool = false; // 살았는지 죽었는지를 판단;
	////////////////////////
	[HideInInspector]
	public int array_display = 0; 
	public float target_distance; //플레이어와의 거리 
	public GameObject attack_ui; // 임시
	

	// Use this for initialization
	void Start () {
		//hp_ = hp_max;
		monster_number = play_system.monster_max_num;
		play_system.monster_unit_num ++;
		play_system.monster_max_num ++;
		play_system.monster_info_list.Add(gameObject);
		damage =0;

	}
	
	// Update is called once per frame
	void Update () {

		if(play_system.turn == 2 && play_system.monster_num == monster_number && die_bool == true){// 죽은 몬스터
			play_system.monster_num ++;
		}
		if(play_system.turn == 2 && play_system.monster_num == monster_number && die_bool == false && GameObject.FindWithTag("dice") == null){ //패턴 판단 
			target = play_system.monster_target[0].transform.gameObject;
			target_distance = Vector3.Distance (transform.position , target.transform.position);
			if(pattern_bool == true){
				pattern_num = 0;
				play_system.playing_uint = transform.gameObject;
				Debug.Log(transform.name + " START PATTERN-------------------------- " );
				hexagon.move_end = false;
				monster_AI.AI_bool = true;
				one_move_pattern = true;
				one_collider_create = true;
				if(target_distance <= attack_range*10){
					monster_AI.monster_info = transform.gameObject;
					Debug.Log(transform.name + " START PATTERN--AI_Battle " );
					monster_AI.AI_Battle();
					pattern_bool = false;
				}
				if(target_distance >attack_range *10){ 
					monster_AI.monster_info = transform.gameObject;
					Debug.Log(transform.name + " START PATTERN--AI_Search " );
					monster_AI.AI_Search();
					pattern_bool = false;
				}

			}
			if(pattern_bool == false){

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

		if(play_system.skill_cast == true){
			Ray ray = new Ray (transform.position,-transform.up);
			RaycastHit hit;
			if(Physics.Raycast(ray ,out hit ,10f)&& hit.collider.gameObject.tag == "hexagon" && die_bool == false){
				range_collider = hit.collider.gameObject.GetComponent<hexagon>().range_collider;
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
			play_system.monster_info_list.Remove(gameObject);
			die_bool = true;
		}
		if(hp_ >= hp_max){
			hp_ = hp_max;
		}
		//////////////////////////////////////////////////////////////////////////////////////
	}





	void move_(){
		if(one_move_pattern == true){
			collider_range_(move_range);
			guide_make = true;
			move_count = move_range;
			one_move_pattern = false;
			Debug.Log ("move / name : " + transform.name);
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
				move_bool = false;
			}
		}

		if(move_count == 0){
			pattern_num = 0;
			active_count ++;
			pattern_bool = true;
		}
	}
	public void attack_(){
		if(one_collider_create == true){
			collider_range_(attack_range);
			one_collider_create = false;
			play_system.one_dice_bool = true;
			play_system.dice_active_num ++;
			Debug.Log("attack start / name : " + transform.name);
		}
		play_system.active_dice_bool = true;
		play_system.selected_unit = transform.gameObject;
		if(play_system.dice_active_num == 3){
			if(target.GetComponent<player>().miss < damage){ // 여기서의 damage 는 명중굴림 수
				play_system.one_dice_bool = true;
				play_system.dice_active_num ++;
				if(damage >= 18){
					criticalHit_bool = true;
				}
				Debug.Log("attack dice - attack OK / name : " + transform.name);
			}
			if(target.GetComponent<player>().miss >= damage){ // 여기서의 damage 는 명중굴림 수
				play_system.one_dice_bool = true;
				pattern_num = 4;
				GameObject dice_s = GameObject.FindWithTag ("dice");
				Destroy(dice_s);
				Debug.Log("attack dice - attack NO / name : " + transform.name);
			}
		}
		if(play_system.dice_active_num == 6){
			GameObject ui_object = Instantiate(attack_ui,new Vector3(target.transform.position.x,20,
			                                                         target.transform.position.z),attack_ui.transform.rotation) as GameObject;
			target.GetComponent<player>().HP_system(damage,criticalHit_bool,transform.gameObject,1);
			Destroy(ui_object,0.5f);
			pattern_num = 4;
			Debug.Log("attack dice - attack - HIT / name : " + transform.name);
		}

	}
	void skill_(){
		if(skill_bool == true){
			if(target_distance > skill_range){
				Debug.Log("skill range no " + transform.name);
				if(active_count >=1)
					wait_();
				if(active_count <=0){
					pattern_num = 1;
					collider_range_(attack_range);
				}
			}
			if(target_distance <= skill_range){
				if(one_skill_bool == true && now_skill == false){
					Debug.Log("skill cast " + transform.name);
					GameObject child = Instantiate(skill,transform.position,transform.rotation) as GameObject;
					child.transform.parent = transform;
					one_skill_bool = false;
				}
				
				if(now_skill == true && one_skill_bool == true){
					GameObject child = Instantiate(skill,transform.position,transform.rotation) as GameObject;
					child.transform.parent = transform;
					one_skill_bool = false;
					pattern_num = 4;
					Debug.Log ("Skill " +transform.name);
				}
			}
		}
		if(skill_bool == false){
			wait_ ();
		}

		/*Debug.Log("skill start / name : " + transform.name);
		if(active_count ==0){
			pattern_num = 1;
		}
		else{
			Debug.Log("skill END / name : " + transform.name);
			wait_();
		}*/
	
	}
	public void wait_(){
		play_system.dice_active_num = 0;
		hexagon.move_end = true;
		play_system.monster_num ++;
		one_move_pattern = true;
		active_count =0;
		pattern_num = 0;
		pattern_bool = true;
		one_skill_bool = true;
		criticalHit_bool = false;
		Debug.Log("wait / name : " + transform.name);

	}
	public void collider_range_(int range)
	{
		collider.GetComponent<range_collider>().range_ = range;
		Instantiate(collider,new Vector3 (transform.position.x,0,transform.position.z),collider.transform.rotation);
	}
	public void HP_system(int damage_number , bool critical,GameObject hit_uint,int kind){
		if(hp_ >= hp_max)
			hp_ = hp_max;
		Me_hit_unit = hit_uint;
		int temp_damage =0;
		if(defense >= damage_number){
			temp_damage = 0;
		}
		else{
			if(critical == true)
				temp_damage = (damage_number*2) - defense;
			if(critical == false)
				temp_damage = damage_number - defense;
		}

		Damage_display[kind].GetComponent<damage_dis>().damage = damage_number;
		hp_ -= temp_damage;
		GameObject dis = Instantiate(Damage_display[kind],transform.position,Damage_display[kind].transform.rotation) as GameObject;
		dis.GetComponent<damage_dis>().damage = temp_damage;
		dis.GetComponent<damage_dis>().array_display = array_display;
		dis.GetComponent<damage_dis>().unit_info = transform.gameObject;
		array_display ++;
		if(critical == true){
			dis.transform.localScale += new Vector3(1,1,1);
		}
		transform.GetComponentInChildren<HP_BAR>().HP_HUD(hp_);
	}	
}
