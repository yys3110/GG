using UnityEngine;
using System.Collections;

public class command_active : MonoBehaviour {
	public GameObject buff;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		for(int i =0; i<play_system.monster_info_list.Count; i++){
			GameObject buff_ = Instantiate(buff) as GameObject;
			buff_.transform.parent = play_system.monster_info_list[i].transform;
		}
		transform.parent.GetComponent<monster>().wait_();
		Destroy(gameObject);
	}
}
