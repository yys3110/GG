﻿using UnityEngine;
using System.Collections;

public class monster_AI : MonoBehaviour {
	
	public static int [,] Search_melee_AI = {{70,20,10},{80,15,5},{90,10,0},{70,30,0}};//테스트로 바꾸는 구간

	public static int [,] Search_range_AI = {{70,20,10},{80,15,5},{90,10,0},{70,30,0}};
	public static int [,] Search_Wizard_AI = {{70,20,10},{60,35,5},{90,10,0},{70,30,0}};

	public static int [,] Battle_melee_AI = {{70,10,20},{5,60,35},{40,30,30},{5,55,45}};//4{5,55,50} 테스트용

	public static int [,] Battle_range_AI = {{10,70,20},{5,65,30},{15,60,25},{5,40,55}};//2{5,65,25}
	public static int [,] Battle_Wizard_AI = {{10,40,50},{5,20,75},{20,30,50},{5,30,65}};
	public static GameObject monster_info;
	public static bool AI_bool = true;
	// 테스트 용
	//public static int [,] Search_melee_AI = {{0,100,0},{80,15,5},{90,10,0},{70,30,0}};
	//public static int [,] Battle_melee_AI = {{0,0,100},{5,60,35},{40,30,30},{5,55,45}};//4{5,55,50}
	public static void AI_Search(){
		if(AI_bool == true){
			monster mon_info = monster_info.GetComponent<monster>();
			Debug.Log ("AI_search  "+mon_info);
			int level = mon_info.monster_level;
			int AI_random = Random.Range(0,101);
			Debug.Log(AI_random +"  " + mon_info.transform.name);
			if(mon_info.monster_class == 0){
				if(AI_random <=Search_melee_AI[level,0])
				{
					if(mon_info.active_count == 0){
						//mon_info.collider.GetComponent<hex_collider>().range_ = mon_info.move_range;
						//mon_info.collider_range_();
						mon_info.pattern_num = 1;
					}
						
					if(mon_info.active_count == 1){
						//AI_random = Random.Range(Search_melee_AI[level,0]+1,101);
						mon_info.pattern_num = 3;
						Debug.Log(AI_random+" monster active count is one / name: " + mon_info.transform.name);
					}
					AI_bool = false;
				}
				if(AI_random > Search_melee_AI[level,0] && AI_random <= Search_melee_AI[level,0]+Search_melee_AI[level,1]){
					mon_info.pattern_num = 3;
				}
				if(AI_random >Search_melee_AI[level,0]+Search_melee_AI[level,1] && AI_random <= Search_melee_AI[level,0]+Search_melee_AI[level,1]+Search_melee_AI[level,2]){
					mon_info.pattern_num = 4;
				}
			}
		}
		AI_bool = false;
	}
	public static void AI_Battle(){

		if(AI_bool == true){
			monster mon_info = monster_info.GetComponent<monster>();
			Debug.Log ("AI_battle  "+mon_info);
			int level = mon_info.monster_level;
			int AI_random = Random.Range(0,101);
			Debug.Log(AI_random+"  " + mon_info.transform.name);
			if(mon_info.monster_class == 0){
				if(AI_random <=Battle_melee_AI[level,0])
				{
					if(mon_info.active_count == 0){
						Debug.Log(mon_info.transform.name + "battle AI - "+Battle_melee_AI[level,0]+"  pattern 1 ");
						mon_info.pattern_num = 1;
					}
					if(mon_info.active_count ==1){
						//AI_random = Random.Range(Battle_melee_AI[level,0]+1,101);
						mon_info.pattern_num = 2;
						Debug.Log(AI_random +" monster active count is one / name : " + mon_info.transform.name);
					}
					AI_bool = false;
				}
				if(AI_random > Battle_melee_AI[level,0] && AI_random <= Battle_melee_AI[level,0]+Battle_melee_AI[level,1]){
					mon_info.pattern_num = 2;
				}
				if(AI_random > Battle_melee_AI[level,0]+Battle_melee_AI[level,1]&& 
				   AI_random <= Battle_melee_AI[level,0]+Battle_melee_AI[level,1]+Battle_melee_AI[level,2]){
					mon_info.pattern_num = 3;
				}
			}
		}
		AI_bool = false;
	}

}
