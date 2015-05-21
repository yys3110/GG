using UnityEngine;
using System.Collections;

public class StrongHealth_active : MonoBehaviour {
	public GameObject[] dice_;
	public int dice_num;


	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<play_system>().dice_systemOn();
		//dice_[dice_num].GetComponent<dice>().skill_On = true;
		//dice_[dice_num].GetComponent<dice>().skill_caster = this.gameObject;
		Instantiate(dice_[dice_num],new Vector3(182.4f,0.5f,-2.75f),dice_[dice_num].transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if(monster.skill_active == 1)
		{
			Camera.main.GetComponent<play_system>().dice_systemOff();
			monster.skill_active = 0;
			//Destroy(gameObject);
		}
	}
}
