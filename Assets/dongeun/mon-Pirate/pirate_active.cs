using UnityEngine;
using System.Collections;
//1D4수치 만큼 기본공격(4턴)
public class pirate_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject[] dice;
	public int count_dice_num = 0;
	public int attack_num = 0;

	GameObject attack_dice;
	GameObject dice_object;
	bool one_dice = true;
	int dice_num_count = 0;
	//int count = 0;
	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<play_system>().dice_system.SetActive(true);
		dice_object = Instantiate(dice[count_dice_num],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
		dice_object.GetComponent<skill_dice>().skill_caster = transform.parent.transform.gameObject;
		dice_object.GetComponent<skill_dice>().OnMouseDown();
		attack_num = transform.parent.gameObject.GetComponent<monster>().dice_code_number;

	}
	
	// Update is called once per frame
	void Update () {
		if(monster.skill_active == 1){
			dice_num_count = transform.parent.transform.gameObject.GetComponent<monster>().temp_skill_dice_num;
		}
		if(monster.skill_active >= 1)
		{
			if(one_dice == true){
				attack_dice = Instantiate(dice[attack_num],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
				attack_dice.GetComponent<skill_dice>().skill_caster = transform.parent.transform.gameObject;
				attack_dice.GetComponent<skill_dice>().OnMouseDown();
				one_dice = false;
			}

			if(monster.skill_active <= dice_num_count+1){
				if(attack_dice.GetComponent<skill_dice>().dice_roll == false){
					int dice_damage = transform.parent.transform.gameObject.GetComponent<monster>().temp_skill_dice_num;
					GameObject target= transform.parent.transform.gameObject.GetComponent<monster>().target;
					target.GetComponent<player>().HP_system(dice_damage,false,transform.parent.transform.gameObject,1);
					if(monster.skill_active > dice_num_count){
						Destroy(gameObject);
						monster.skill_active = 0;
						transform.parent.transform.gameObject.GetComponent<monster>().wait_();
						Camera.main.GetComponent<play_system>().dice_system.SetActive(false);
					}
					Destroy(attack_dice);
					one_dice = true;
				}
			}
			if(dice_object != null){
				Destroy(dice_object);
			}
		}
	}
}
