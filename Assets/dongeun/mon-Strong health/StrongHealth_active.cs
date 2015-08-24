using UnityEngine;
using System.Collections;

public class StrongHealth_active : MonoBehaviour {
	public GameObject [] skill_dice;
	public int skill_dice_num = 1;
	public int turn_cooltime;
	int basic_dice;
	int skill_damage = 0;
	int basic_damage = 0;
	GameObject basic_dice_object;
	GameObject skill_dice_object;
	bool basic_ok_bool = false;
	bool skill_ok_bool = false;
	float del = 0;
	bool one_damage_bool = true;

	void Start () {
		Camera.main.GetComponent<play_system>().dice_systemOn();
		basic_dice = transform.parent.GetComponent<monster>().dice_code_number;
		basic_dice_object = Instantiate(skill_dice[basic_dice],new Vector3(182.4f,0.5f,-2.75f),skill_dice[basic_dice].transform.rotation) as GameObject;
		skill_dice_object = Instantiate(skill_dice[skill_dice_num],new Vector3(185.0f,0.5f,-2.75f),skill_dice[skill_dice_num].transform.rotation) as GameObject;
		basic_dice_object.GetComponent<skill_dice>().OnMouseDown();
		skill_dice_object.GetComponent<skill_dice>().OnMouseDown();

	}
	
	// Update is called once per frame
	void Update () {
		if(del <= 0.6f)
		del += Time.deltaTime;
		if(del >= 0.5f){
			basic_dice_object.GetComponent<skill_dice>().skill_caster_reg_bool = false;
			skill_dice_object.GetComponent<skill_dice>().skill_caster_reg_bool = false;

			if(basic_dice_object.GetComponent<skill_dice>().velocityd <=0){
				basic_damage = basic_dice_object.GetComponent<skill_dice>().dice_num;
				basic_ok_bool = true;
			}
			if(skill_dice_object.GetComponent<skill_dice>().velocityd <=0){
				skill_damage = skill_dice_object.GetComponent<skill_dice>().dice_num;
				skill_ok_bool = true;
			}
		}
		if(basic_ok_bool == true && skill_ok_bool == true){
			del += Time.deltaTime;
			if(del >= 2f){
				if(one_damage_bool == true){
					transform.parent.GetComponent<monster>().target.GetComponent<player>().HP_system(basic_damage+skill_damage,false,transform.parent.gameObject,1);
					one_damage_bool = false;
				}
				Destroy(basic_dice_object);
				Destroy(skill_dice_object);
				Camera.main.GetComponent<play_system>().dice_systemOff();
				transform.parent.GetComponent<monster>().wait_();
				Destroy(gameObject);
			}
		}
	}
}