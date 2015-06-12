using UnityEngine;
using System.Collections;

public class Godsbody_active : MonoBehaviour {
	int count = 0;
	int MAX_count = 0;
	public int passive_turn = 0;

	int defense_ = 0; // 초기 방어값 저장
	// Use this for initialization
	void Start () {
		count = play_system.game_turn+1;
		MAX_count = count + passive_turn;
		Debug.Log ("count" + count);
		Debug.Log ("MAX_count" + MAX_count);
		defense_ = transform.parent.gameObject.GetComponent<monster>().defense;
		transform.parent.gameObject.GetComponent<monster>().defense = 9999;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(count == play_system.game_turn){
			count ++;

			if(count == MAX_count){
				transform.parent.gameObject.GetComponent<monster>().defense = defense_;
				Destroy(gameObject);
			}

		}
	}
}