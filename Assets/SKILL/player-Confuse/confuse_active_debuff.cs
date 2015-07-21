using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class confuse_active_debuff : MonoBehaviour {
	public int turn = 1;
	public float min_distance =100;
	public int target_num; // min_distance 에서 제일 적은 값을 가진 오브젝트 의 번호
	public List <GameObject> list_uint;

	public GameObject [] monster_unit;
	public GameObject [] player_unit;
	public GameObject [] dice_;

	GameObject dice_object;
	int dice_num;
	// Use this for initialization
	void Start () {
		monster mons = transform.parent.GetComponent<monster>();
		mons.pattern_bool = false;
		mons.pattern_num = 0;
		transform.localPosition = new Vector3(0,2,0);
		monster_unit = GameObject.FindGameObjectsWithTag("monster");
		player_unit = GameObject.FindGameObjectsWithTag("player");

		for(int i =0; i < monster_unit.Length; i++){
			list_uint.Add(monster_unit[i]);
		}
		for(int i = 0; i < player_unit.Length; i++){
			list_uint.Add(player_unit[i]);
		}
		for(int i =	0; i< list_uint.Count; i++){
			float distance = Vector3.Distance(transform.parent.transform.position, list_uint[i].transform.position);
			if(distance <= min_distance && distance != 0){
				min_distance = distance;
				target_num = i;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,1,0);
		monster mons = transform.parent.GetComponent<monster>();
		float distance = Vector3.Distance(transform.parent.position,list_uint[target_num].transform.position);
		if(play_system.monster_num == transform.parent.GetComponent<monster>().monster_number && distance <= mons.attack_range*10){
			if(monster.skill_active == 0){
				Camera.main.GetComponent<play_system>().dice_system.SetActive(true);
				dice_object = Instantiate(dice_[5],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
				dice_object.GetComponent<skill_dice>().type = 1;
				dice_object.GetComponent<skill_dice>().OnMouseDown();
				monster.skill_active ++;
				Debug.Log(" skill_dice   "+ transform.parent.gameObject.name);
			}
			if(monster.skill_active == 2){
				dice_num = play_system.play_dice_num;
				Debug.Log("dice number is : "+dice_num);
				if(list_uint[target_num].gameObject.tag == "player"){
					player player_unit = list_uint[target_num].GetComponent<player>();
					if(player_unit.miss < dice_num){
						monster.skill_active ++;
					}
					if(player_unit.miss >= dice_num){
						mons.wait_();
						monster.skill_active =0;
						Camera.main.GetComponent<play_system>().dice_system.SetActive(false);
						Destroy(gameObject);
					}
				}
				if(list_uint[target_num].gameObject.tag == "monster"){
					monster monster_unit = list_uint[target_num].GetComponent<monster>();
					if(monster_unit.miss < dice_num){
						monster.skill_active ++;
					}
					if(monster_unit.miss >= dice_num){
						mons.wait_();
						monster.skill_active =0;
						Camera.main.GetComponent<play_system>().dice_system.SetActive(false);
						Destroy(gameObject);
					}
				}
				Destroy(dice_object.gameObject);
			}
			if(monster.skill_active == 3){
				dice_object = Instantiate(dice_[mons.dice_code_number],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
				dice_object.GetComponent<skill_dice>().type = 1;
				dice_object.GetComponent<skill_dice>().OnMouseDown();
				monster.skill_active ++;
			}
			if(monster.skill_active == 5){
				if(list_uint[target_num].gameObject.tag == "player"){
					list_uint[target_num].GetComponent<player>().HP_system(play_system.play_dice_num,false,transform.parent.gameObject,2);
				}
				if(list_uint[target_num].gameObject.tag == "monster"){
					list_uint[target_num].GetComponent<monster>().HP_system(play_system.play_dice_num,false,transform.parent.gameObject,2);
				}
				mons.wait_();
				monster.skill_active =0;
				Camera.main.GetComponent<play_system>().dice_system.SetActive(false);
				Destroy(dice_object.gameObject);
				Destroy(gameObject);
			}
		}
	}
}
