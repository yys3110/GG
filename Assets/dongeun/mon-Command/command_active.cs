using UnityEngine;
using System.Collections;

public class command_active : MonoBehaviour {
	public int turn_cooltime;
	public float del;
	public bool skill1 = false;
	public bool skill2 = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 1){
			if(skill1 == false){
				foreach(var tmonster in play_system.monster_info_list)
				{
					Debug.Log("나를 따르라!");
					tmonster.GetComponent<monster>().move_range += 1;
					tmonster.GetComponent<monster>().attack_range += 1;
					skill1 = true;
				}
				if(play_system.turn == 2){
					skill2 = true;
				}
			}
		}
		if(play_system.turn == 1 && skill2 == true){
			foreach(GameObject tmonster in play_system.monster_info_list)
			{
				tmonster.GetComponent<monster>().move_range -= 1;
				tmonster.GetComponent<monster>().attack_range -= 1;
			}
			Destroy(gameObject);
		}
	}
}
