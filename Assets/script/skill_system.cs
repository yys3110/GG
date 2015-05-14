using UnityEngine;
using System.Collections;

public class skill_system : MonoBehaviour {
	public GameObject skill_list;
	public int damega;
	public int skill_range;
	public int move_range;
	public int miss;
	public int defense;
	//유닛정보 
	public GameObject player_info;
	public GameObject monster_info;
	//
	bool one_skill_bool = true;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	
			
		
	}
	void skill_cast(){
		Instantiate(skill_list,transform.position,skill_list.transform.rotation);
	}
}
