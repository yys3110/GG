using UnityEngine;
using System.Collections;
//폭신 페시브
public class ExplosionBody_passive : MonoBehaviour {
	public Vector3 player_pos;
	public bool one_passive = false;
	public GameObject range_collider;
	public int range = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(play_system.turn == 2){

			if(play_system.dice_active_num == 6){
				one_passive = true;

			}
		}
		if(one_passive == true){
			Debug.Log("들어왔다 꺄~");
			player_pos = transform.parent.GetComponent<monster>().target.transform.position;
			range_collider.GetComponent<SphereCollider>().enabled = true;
			range_collider.GetComponent<range_collider>().skill_damage = 1;
			range_collider.GetComponent<range_collider>().skill_splash_collider = true;
			hexagon.move_end = false;
			range_collider.GetComponent<range_collider>().range_ = range;
			Instantiate(range_collider,new Vector3(player_pos.x,0,player_pos.z), range_collider.transform.rotation);
			one_passive = false;
		}
	}
}