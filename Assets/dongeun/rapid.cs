using UnityEngine;
using System.Collections;
//신속 스킬
public class rapid : MonoBehaviour {
	public int turn_cooltime;
	// Use this for initialization
	void Start () {
		GetComponent<player>().move_range = 6;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
