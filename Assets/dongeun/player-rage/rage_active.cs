using UnityEngine;
using System.Collections;

public class rage_active : MonoBehaviour {
	public int skill = 0;
	// Use this for initialization
	void Start () {
		skill = transform.parent.GetComponent<player>().move_range;
		transform.parent.GetComponent<player>().add_damage = skill;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
