using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class play_system : MonoBehaviour {

	public static int turn = 1; // 0 : not , 1 : player turn, 2 : monster turn//
	public static int player_max_num =0;
	public static int monster_max_num=0;
	public static int player_num =0; // 진행 상황  플레이어 캐릭터의 몇번째 를 나타낸다
	public static int monster_num =0;  // 몬스터 진행상황
	public static int player_unit_num; // 플레이어 유닛이 몇마리 남아있는지를 확인
	public static int monster_unit_num; // 몬스터 유닛이 몇마리 남아있는지를 확인
	public static int game_turn =0; //이번판의 게임의 총 턴 횟수, 플레이어 턴마다 +1 을 한다 ;
	public static GameObject playing_uint; // 현재 컨트롤 하고있는 유닛
	//임시 테스트 
	public int player_nums;
	public int player_nums_max;
	public int monster_nums;
	public int monster_nums_max;
	public int player_units;
	public int monster_units;
	public bool temp_active_dice_bool = false;
	public int turns;
	//
	public TextMesh text_;
	public bool one_bool = true;
	public static GameObject selected_unit; // 여기에 저장된 유닛을 dice에 나온 값을 넣는다
	//주사위 시스템
	public GameObject dice_system;
	public static bool one_dice_bool = false; // dice_sysyem 한번만 활성화 시킴
	public static bool active_dice_bool = false; // 전체적인 dice 시스템 bool 
	public static int play_dice_num = 0;
	public static int dice_active_num=0; // 상황 진행도 0:중립
	public static bool monster_one_dice_bool = true; // dice 의 active 문제로 여기서 운영
	public GameObject [] dice_object;
	//
	public static List<GameObject> monster_target = new List<GameObject>();//player 정보 입력되있음
	public static List<bool> target_on_bool = new List<bool>();
	public static List<GameObject> monster_info_list = new List<GameObject>();//monster 정보 입력되있음
	public List<GameObject> mon;
	public List<bool> mon_bool;
	// UI 시스템 관련 
	public GameObject UI_field;
	//치트
	public GameObject cheat;
	// Use this for initialization
	void Start () {
		turn = 1;
	}
	
	// Update is called once per frame
	void Update () {
		mon = monster_target;
		mon_bool = target_on_bool;
		turns = turn;
		player_nums = player_num;
		player_nums_max = player_max_num;
		monster_nums = monster_num;
		monster_nums_max = monster_max_num;
		player_units = player_unit_num;
		monster_units = monster_unit_num;
		temp_active_dice_bool = active_dice_bool;
		if(player_num >= player_max_num && !(player_unit_num ==0))
		{
			turn = 2;
			player_num =0;
			one_bool = true;
			Debug.Log(turn +"턴---------------------------------------");
		}
		if(monster_num >= monster_max_num && !(monster_unit_num ==0))
		{
			turn = 1;
			monster_num = 0;
			one_bool = true;
			Debug.Log(turn +" 턴---------------------------------------");
		}
		if(player_unit_num ==0){ // 플레이어 유닛수가 0이면 패배
			text_.text = "ENEMY VICTORY !!";
			turn = 0;
			dice_system.active = false;
		}
		if( monster_unit_num ==0){ // 몬스터 유닛수가 0이면 패배
			text_.text = "PLAYER VICTORY !!";
			turn = 0;
			dice_system.active = false;
		}

		if(turn ==1)
		{
			if(one_bool == true)
			{
				text_.text = "PLAYER TURN !";
				one_bool = false;
				player.unit_active_bool = true;
				game_turn ++;
				Debug.Log (game_turn);
			}
		}

		if(turn ==2)
		{
			if(one_bool == true)
			{
				text_.text = "ENEMY TURN !";
				one_bool = false;
			}
		}

		if(active_dice_bool == true && GameObject.FindWithTag("dice") == null){
			dice_();
		}

		if(Input.GetKeyDown(KeyCode.Q)){
			GOD_SWORD.god_bool = true;
			Instantiate(cheat);
		}
		if(Input.GetKeyUp(KeyCode.Q)){
			GOD_SWORD.god_bool = false;
		}

	}

	void dice_(){
		if(one_dice_bool == true){
			if(dice_active_num == 1){
				dice_system.active = true;
				Instantiate(dice_object[5],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0));
				one_dice_bool = false;
			}
			if(dice_active_num == 4){
				dice_system.active = true;
				if(turn ==1)
				Instantiate(dice_object[selected_unit.GetComponent<player>().dice_code_number],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0));
				if(turn ==2)
				Instantiate(dice_object[selected_unit.GetComponent<monster>().dice_code_number],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0));
				one_dice_bool = false;
			}
		}
		if(dice_active_num == 2){
			if(turn == 1)
				selected_unit.GetComponent<player>().damage += play_dice_num;
			if(turn == 2)
				selected_unit.GetComponent<monster>().damage += play_dice_num;
			monster_one_dice_bool = true;
			dice_system.active = false;
			hexagon.move_end = true;
			dice_active_num = 3;
		}
		if(dice_active_num == 5){
			if(turn == 1){
				selected_unit.GetComponent<player>().damage = 0;
				selected_unit.GetComponent<player>().damage += play_dice_num;
			}

			if(turn == 2){
				selected_unit.GetComponent<monster>().damage =0;
				selected_unit.GetComponent<monster>().damage += play_dice_num;
			}

			dice_system.active = false;
			monster_one_dice_bool = true;
			dice_active_num = 6;
			active_dice_bool = false;
		}

	}
	public void dice_systemOn(){
		dice_system.SetActive(true);
	}
	public void dice_systemOff(){
		dice_system.SetActive(false);
	}
}
