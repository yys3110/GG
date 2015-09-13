using UnityEngine;
using System.Collections;
public class ContinuousFire_active : MonoBehaviour {
	public GameObject [] dice;
	public GameObject range_collider;
	public int attack_range =4;
	GameObject dice_object;
	bool one_bool = true;
	bool one_damage = true;
	int temp_damage =0;
	public GameObject[] player_list;
	// Use this for initialization
	void Start () {
		hexagon.move_end = false;
		GameObject range = Instantiate(range_collider,transform.position - new Vector3(0,5,0),range_collider.transform.rotation) as GameObject;
		range.GetComponent<range_collider>().range_ = attack_range;
		int dice_num = transform.parent.GetComponent<monster>().dice_code_number;
		Camera.main.GetComponent<play_system>().dice_systemOn();
		dice_object = Instantiate(dice[dice_num],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
		dice_object.GetComponent<skill_dice>().OnMouseDown();
		player_list = GameObject.FindGameObjectsWithTag("player");
	}
	
	// Update is called once per frame
	void Update () {
		if(one_bool == true){
			dice_object.GetComponent<skill_dice>().skill_caster_reg_bool = false;
			dice_object.GetComponent<skill_dice>().OnMouseDown();
			one_bool =false;
		}
		if(dice_object.GetComponent<skill_dice>().velocityd <= 0.0f && dice_object.GetComponent<skill_dice>().dice_roll == false){
			temp_damage = dice_object.GetComponent<skill_dice>().dice_num;
			int damage = temp_damage/2;
			if(one_damage == true){
				for(int i = 0; i< player_list.Length; i++){
					if(player_list[i].GetComponent<player>().range_collider == true){
						Debug.Log("two ddd");
						player_list[i].GetComponent<player>().HP_system(damage,false,transform.parent.transform.gameObject,1);
					}
				}
				one_damage = false;
				Destroy(dice_object.gameObject);
				transform.parent.GetComponent<monster>().wait_();
				Camera.main.GetComponent<play_system>().dice_systemOff();
				Destroy(gameObject);
			}
		}
	}
}
