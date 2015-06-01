using UnityEngine;
using System.Collections;

public class command_active : MonoBehaviour {
	public float del;
	public bool one = true;
	// Use this for initialization
	void Start () {
		transform.parent.transform.gameObject.GetComponent<monster>().wait_();
		/*for(int i = 0;i<= play_system.monster_info_list.Count; i++)
		{
			play_system.monster_info_list[i]
			.GetComponent<monster>().move_range += 1;
			play_system.monster_info_list[i].GetComponent<monster>().attack_range += 1;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if(one == true){
				foreach(var tmonster in play_system.monster_info_list)
				{
					Debug.Log("나를 따르라!");
					tmonster.GetComponent<monster>().move_range += 1;
					tmonster.GetComponent<monster>().attack_range += 1;
				}
				one = false;
		}
		if(play_system.turn == 1 && one == false){
			foreach(GameObject tmonster in play_system.monster_info_list)
			{
				tmonster.GetComponent<monster>().move_range -= 1;
				tmonster.GetComponent<monster>().attack_range -= 1;
			}
			Destroy(gameObject);
		}
	}
}
