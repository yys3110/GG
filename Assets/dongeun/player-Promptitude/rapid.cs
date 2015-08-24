using UnityEngine;
using System.Collections;
//신속 스킬
public class rapid : MonoBehaviour {
	public int move_range = 3;
	int turn = 0;

	// Use this for initialization
	void Start () {
		turn = play_system.game_turn;
		transform.parent.GetComponent<player>().move_range += move_range;
		transform.parent.GetComponent<player>().wait_();



	}
	
	// Update is called once per frame
	void Update () {
		if(turn+2 == play_system.game_turn){
			turn++;
			transform.parent.GetComponent<player>().move_range -= move_range;
			Destroy(gameObject);
		}
	}
}
