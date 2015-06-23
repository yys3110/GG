using UnityEngine;
using System.Collections;

public class swordemperor_passive : MonoBehaviour {
	public GameObject player_unit;
	public GameObject[] dice;
	public int dice_dnum;

	bool dice_ = true;
	int dice_num_ = 0;
	int hp = 0;
	int num = 0;
	float del = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if(play_system.turn == 2){
			if(play_system.dice_active_num == 4){
				if(play_system.monster_num == transform.parent.transform.gameObject.GetComponent<monster>().monster_number){
					if(GameObject.FindWithTag ("dice") != null){
						Destroy(GameObject.FindWithTag ("dice"));
					}
				}
				if(dice_ == true){
					//Camera.main.GetComponent<play_system>().dice_systemOn();
					Camera.main.GetComponent<play_system>().dice_system.SetActive(true);
					Instantiate(dice[dice_dnum],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0));
					dice_ = false;
				}
				//play_system.dice_active_num = 5;
			}
		
		}*/
		player_unit = transform.parent.transform.gameObject.GetComponent<monster>().target;
		if(play_system.turn == 2){
			if(play_system.monster_num == transform.parent.transform.gameObject.GetComponent<monster>().monster_number){
				if(play_system.dice_active_num == 5){
					Debug.Log ("죽어라");

					dice_num_ = play_system.play_dice_num;
					hp = player_unit.GetComponent<player>().hp_;
					if(dice_num_ >= hp){

						player_unit.GetComponent<player>().HP_system
							(dice_num_,transform.parent.transform.gameObject.GetComponent<monster>().criticalHit_bool,transform.parent.transform.gameObject,1);
						transform.parent.transform.gameObject.GetComponent<monster>().target = play_system.monster_target[0].transform.gameObject;
						transform.parent.transform.gameObject.GetComponent<monster>().target_distance = Vector3.Distance (transform.position , player_unit.transform.position);
						play_system.dice_active_num = 1;
						hexagon.move_end = true;
						transform.parent.transform.gameObject.GetComponent<monster>().one_move_pattern = true;
						//transform.parent.transform.gameObject.GetComponent<monster>().active_count = 0;
						transform.parent.transform.gameObject.GetComponent<monster>().pattern_num = 2;
						transform.parent.transform.gameObject.GetComponent<monster>().pattern_bool = true;
						transform.parent.transform.gameObject.GetComponent<monster>().one_skill_bool = true;
						transform.parent.transform.gameObject.GetComponent<monster>().criticalHit_bool = false;
						transform.parent.transform.gameObject.GetComponent<monster>().attack_();

						/*if(dice_num_ < hp){
						Debug.Log ("살았네?");
						Camera.main.GetComponent<play_system>().dice_system.SetActive(false);
						play_system.monster_one_dice_bool = true;
						play_system.dice_active_num = 6;
						play_system.active_dice_bool = false;
					}*/
					}
				}
			}
		}
	}
}
