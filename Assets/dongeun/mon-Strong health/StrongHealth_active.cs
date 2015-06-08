using UnityEngine;
using System.Collections;

public class StrongHealth_active : MonoBehaviour {
	public GameObject[] dice_;
	public int dice_num;
	public int turn_cooltime;


	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<play_system>().dice_systemOn();
		Instantiate(dice_[dice_num],new Vector3(182.4f,0.5f,-2.75f),dice_[dice_num].transform.rotation);
		play_system.turn = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(monster.skill_active == 1)
		{
			Camera.main.GetComponent<play_system>().dice_systemOff();
			monster.skill_active = 0;
			Destroy(gameObject);
		}
	}
}