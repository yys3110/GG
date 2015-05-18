using UnityEngine;
using System.Collections;

public class StrongHealth_active : MonoBehaviour {
	public GameObject Dice6;
	public int active_num =0;


	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<play_system>().dice_systemOn();
		Dice6.GetComponent<dice>().skill_caster = this.gameObject;
		Instantiate(Dice6,new Vector3(182.4f,0.5f,-2.75f),Dice6.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if(monster.skill_active == 1)
		{
			transform.parent.GetComponent<monster>().pattern_num = 2;
			monster.skill_active = 0;
			Destroy(gameObject);
		}
	}
}
