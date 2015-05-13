using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public Vector3 mouse_hex_pos;
	public static bool mouse_over = false;
	public bool mouse_click = false;
	public GameObject mouse_hit_hex;
	public GameObject guide_;
	public GameObject guide_group;
	public GameObject guide_system; // 바뀐거 
	bool one_guide_group = true;
	public Vector3 [] move_guide_pos = new Vector3[50];
	public bool move_bool = false;
	public int pos_num;
	public Vector3 mouse_distance;
	public int guide_num;
	public GameObject collider; // 범위
	public bool character_select = false; // 캐릭터가 클릭이 되는가를 확인 
	public bool chance_turn = true; // 캐릭터 차례 확인
	public static bool player_click = true; // 플레이어 캐릭터 클릭
	public bool range_collider = false; // enemy 범위에 속해 있는가를 판별
	public static bool unit_active_bool = false; // 유닛 활성화 컨트롤
	public int active_num; // 0 : 중립, 1 : move, 2: attack, 3: wait, 4: cancel 할 행동을 정함 << UI_SYSTEM 연동
	public GameObject attack_ui; // 임시
	public GameObject field_UI; // 필드 ui 게임 오브젝트;
	bool one_monster_click = true;
	public GameObject monster_unit; // 클릭 한 몬스터의 정보가 입력;
	bool one_die_check = true;
	// 카메라
	Vector3 camera_default_pos = new Vector3(31,70,-155);
	bool camera_move_bool = false;
	int camera_num =0; // 카메라의 구도;
	// 캐릭터 능력 
	public float speed = 10;
	//캐릭터 정보//
	public bool ______________;
	public int code_number;
	public int hp_,damage,miss,attack_range,move_range;
	public bool skill;
	public int skill_number;
	public int character_class;
	public int dice_code_number =0; // 0 : 4면체 , 1 : 6면 , 2 : 8면 ,3 : 10면 , 4 : 12면체 , 5 : 20면체 (명중굴림)
	public bool die_bool = false;
	// Use this for initialization
	void Start () {
		play_system.player_unit_num ++;
		play_system.player_max_num ++;
		play_system.monster_target.Add(gameObject);
		play_system.target_on_bool.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(die_bool == true){

		}
		if(play_system.turn == 1 && character_select == true && die_bool == false){
			if(active_num == 1){
				move_();
			}
			if(active_num == 2){
				attack_();
			}
			if(active_num == 3){
				wait_();
			}
			if(active_num == 4){
				cancel_();
			}
		}
	
		if(play_system.turn == 2){
			Ray ray = new Ray (transform.position,-transform.up);
			RaycastHit hit;
				if(Physics.Raycast(ray, out hit , 10f)&& hit.collider.gameObject.tag == "hexagon" && die_bool == false){
					range_collider = hit.collider.gameObject.GetComponent<hexagon>().range_collider;
				}
			one_die_check = true;
		}
		if(die_bool == false){
			if(chance_turn == true)
			{
				transform.GetComponentInChildren<Renderer>().material.color = new Color(transform.GetComponentInChildren<Renderer>().material.color.r,
				transform.GetComponentInChildren<Renderer>().material.color.g,transform.GetComponentInChildren<Renderer>().material.color.b,1f);
			}
			if(chance_turn == false)
			{
				transform.GetComponentInChildren<Renderer>().material.color = new Color(transform.GetComponentInChildren<Renderer>().material.color.r,
				transform.GetComponentInChildren<Renderer>().material.color.g,transform.GetComponentInChildren<Renderer>().material.color.b,0.5f);
			}
		}
		if(unit_active_bool == true){
			chance_turn = true;
		}

		if(camera_move_bool == true){
			if(camera_num == 1){
				Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, 
				new Vector3(transform.position.x,transform.position.y+50,transform.position.z -50),Time.deltaTime *50);
				float distance = Vector3.Distance(Camera.main.transform.position, new Vector3(transform.position.x,transform.position.y+50,transform.position.z-50));
				if(distance == 0){
					camera_move_bool = false;
				}
			}
			if(camera_num == 2){
				Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,camera_default_pos,Time.deltaTime *100);
				float distance = Vector3.Distance(Camera.main.transform.position ,camera_default_pos);
				if(distance == 0){
					camera_move_bool = false;
				}
			}
		}
		//플레이어 HP
		if(hp_ <=0 && die_bool == false){
			play_system.player_unit_num --;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			this.gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1,1,1,0);
			Ray ray = new Ray(transform.position,-transform.up);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,Mathf.Infinity)&&hit.collider.gameObject.tag == "hexagon"){
				hit.collider.gameObject.GetComponent<hexagon>().hexagon_unit_bool = false;
			}
			play_system.target_on_bool.RemoveAt(play_system.monster_target.IndexOf(gameObject));
			play_system.monster_target.Remove(gameObject);
			die_bool = true;
		}

		if(play_system.turn == 1 && die_bool == true){
			if(one_die_check == true){
				play_system.player_num ++;
				one_die_check = false;
			}
		}
	}


	void OnMouseDown()
	{
		if(play_system.turn ==1 && chance_turn == true && player_click == true)
		{
			character_select = true;
			player_click = false;

			field_UI.active = true; //필드 ui 시스템
			field_UI.transform.position = new Vector3(transform.position.x+15,15,transform.position.z);
			field_UI.GetComponent<ui_field_system>().unit_info = transform.gameObject;
			camera_move_bool = true;
			camera_num = 1;
			play_system.selected_unit = transform.gameObject; // 플레이 시스템 - selected_unit 에 플레이어 유닛 저장
		}
	}
	void OnField_ui(){

		if(active_num == 1){
			hexagon.move_end = false;
			collider.GetComponent<hex_collider>().range_ = 6.9f;
			Instantiate(collider,new Vector3 (transform.position.x,0,transform.position.z),collider.transform.rotation);// 거리 범위 생성
			unit_active_bool = false; // 플레이어 턴 에서 플레이어 유닛을 클릭 하면 unit_active_bool 이 false 가 되어 활성화 bool 은 꺼진다
		}
		if(active_num == 2){
			hexagon.move_end = false;
			collider.GetComponent<hex_collider>().range_ = 2f;
			Instantiate(collider, new Vector3(transform.position.x,0,transform.position.z),collider.transform.rotation);
			unit_active_bool = false;
		}
		
	}
	void OnGUI()
	{
		if(character_select == true)
		{
			if(GUI.RepeatButton(new Rect(100,100,20,20),"취소 후 다른캐릭터 선택"))
			{
				character_select = false;
				hexagon.move_end = true;
				player_click = true;
			}
		}
	}

	void move_(){

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
			
		mouse_over = false;
		if(mouse_over == false && mouse_hit_hex != null){
			mouse_hit_hex.GetComponent<Renderer>().material.color = new Color(0.5f,0.5f,0.5f,0.5f);
		}
		if(Physics.Raycast(ray, out hit , Mathf.Infinity)){
			if(hit.collider.tag == "hexagon" && hit.collider.GetComponent<hexagon>().range_collider == true){
				mouse_distance= hit.collider.gameObject.transform.position; //바뀜 
				mouse_over = true;
				if(mouse_hit_hex != null){
					mouse_hit_hex.GetComponent<Renderer>().material.color = new Color (0.5f,0.5f,0.5f,0.5f);
				}
				mouse_hit_hex = hit.collider.gameObject;
				mouse_hit_hex.GetComponent<Renderer>().material.color = new Color (1,0,0,0.5f);
				mouse_hex_pos = mouse_hit_hex.transform.position;
				mouse_hit_hex.GetComponent<hexagon>().mouse_over_bool = true;
				if(one_guide_group == true){
					guide_.GetComponent<guild>().end_pos = mouse_hex_pos;
					guide_system.GetComponent<guide_system>().mouse_distance = mouse_distance;
					guide_system.GetComponent<guide_system>().player = transform.gameObject;
					GameObject guide_g = Instantiate(guide_system,new Vector3 (transform.position.x,1,transform.position.z),transform.rotation) as GameObject;
					Instantiate (guide_group,transform.position,transform.rotation);
					GameObject guide_p = GameObject.FindWithTag("guide_group");
					guide_g.transform.parent = guide_p.transform;
					one_guide_group = false;
					}
					if(Input.GetKeyDown(KeyCode.Mouse0) && move_range-1 >= guide_num){
						move_bool = true;
					}
				}
			}
		if(mouse_over == false && move_bool == false){
			Destroy(GameObject.FindWithTag ("guide_group"));
			move_guide_pos = new Vector3[50];
			guide_num = 0;
			one_guide_group = true;
		}
		if(move_bool == true){
			float distance = Vector3.Distance (transform.position, mouse_hex_pos);
			move_guide_pos[guide_num] = mouse_hex_pos;
			if(distance == 0){
				pos_num = 0;
				guide_num = 0;
				move_bool = false;
			}
			float distance_guide = Vector3.Distance (transform.position, new Vector3 (move_guide_pos[pos_num].x,5,move_guide_pos[pos_num].z));
			if(distance_guide !=0){
				transform.localPosition = Vector3.MoveTowards (transform.position , new Vector3 (move_guide_pos[pos_num].x,5,move_guide_pos[pos_num].z) , Time.deltaTime * speed);
			}
			if(distance_guide <=0){
				//transform.position = new Vector3 (transform.position.x,10,transform.position.z);
				if(guide_num-1 < pos_num){
					hexagon.move_end = true;
					Destroy(GameObject.FindWithTag("guide_group"));
					//character_select = false;
					//chance_turn = false;
					//player_click = true;
					field_UI.active = true; //필드 ui 시스템
					field_UI.transform.position = new Vector3(transform.position.x+15,15,transform.position.z);
					field_UI.GetComponent<ui_field_system>().ui_move_bool = false;
					field_UI.GetComponent<ui_field_system>().ui_cancel_bool = false;
					camera_num = 1; // 카메라 움직임
					camera_move_bool = true; // 카메라 움직임

					active_num = 0;
					move_bool = false;
				}
				pos_num ++;
			}
				
		}
		if(move_bool == false){
			pos_num =0;	
		}
	}
	void attack_(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit , Mathf.Infinity) && hit.collider.gameObject.tag == "monster"){
			if(hit.collider.GetComponent<monster>().range_collider == true){
				if(Input.GetKeyDown(KeyCode.Mouse0) && one_monster_click == true){
					monster_unit = hit.collider.gameObject;
					play_system.one_dice_bool = true;
					play_system.active_dice_bool = true;
					play_system.dice_active_num ++;
					one_monster_click = false;
				}
			}
		}
		if(play_system.dice_active_num == 3){
			if(monster_unit.GetComponent<monster>().miss < damage){ // damage는 명중굴림,실패 시
				play_system.one_dice_bool = true;
				play_system.dice_active_num ++;
			}
			if(monster_unit.GetComponent<monster>().miss >= damage){ // 여기서의 damage 는 명중굴림 수
				chance_turn = false;
				player_click = true;
				one_monster_click = true;
				hexagon.move_end = true;
				active_num = 0;
				camera_move_bool = true; // 카메라 움직임
				camera_num = 2; // 카메라 움직임
				play_system.player_num ++;
				play_system.dice_active_num =0; // 초기화
				play_system.active_dice_bool = false;
				field_UI.GetComponent<ui_field_system>().ui_move_bool = true;
				field_UI.GetComponent<ui_field_system>().ui_cancel_bool = true;
			}


		}
		if(play_system.dice_active_num == 6){
			GameObject ui_des = Instantiate(attack_ui,new Vector3(monster_unit.transform.position.x,20,
			monster_unit.transform.position.z),attack_ui.transform.rotation) as GameObject;
			monster_unit.GetComponent<monster>().hp_ -= damage;
			Destroy(ui_des,0.5f);
			chance_turn = false;
			player_click = true;
			one_monster_click = true;
			hexagon.move_end = true;
			active_num = 0;
			camera_move_bool = true; // 카메라 움직임
			camera_num = 2; // 카메라 움직임
			play_system.player_num ++;
			play_system.dice_active_num =0; // 초기화
			field_UI.GetComponent<ui_field_system>().ui_move_bool = true;
			field_UI.GetComponent<ui_field_system>().ui_cancel_bool = true;
		}
	}
	void wait_(){
		chance_turn = false;
		player_click = true;
		unit_active_bool = false;
		active_num = 0;
		camera_move_bool = true;
		camera_num = 2;
		play_system.player_num ++;
		//field_UI.SendMessage("reset_bool","1");
		field_UI.GetComponent<ui_field_system>().ui_move_bool = true;
		field_UI.GetComponent<ui_field_system>().ui_cancel_bool = true;
	}
	void cancel_(){
		character_select = false;
		hexagon.move_end = true;
		player_click = true;
		active_num = 0;
		camera_move_bool = true;
		camera_num = 2;
	}
}
