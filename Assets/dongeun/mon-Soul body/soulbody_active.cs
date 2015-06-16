using UnityEngine;
using System.Collections;

public class soulbody_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject buff;

	bool one = true;
	float del;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(one == true){
			del += Time.deltaTime;
			if(del >= 0.5f){
				foreach(var soulbody in play_system.monster_info_list)
				{
					GameObject child = Instantiate(buff,transform.position,buff.transform.rotation) as GameObject;
					child.transform.parent = soulbody.transform;
				}
				one = false;
			}
		}
	}
}
