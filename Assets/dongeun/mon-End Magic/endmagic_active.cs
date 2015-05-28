using UnityEngine;
using System.Collections;

public class endmagic_active : MonoBehaviour {
	public float del;
	public bool one = true;
	public int active_damage; // 고정피해
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(one == true){
			del += Time.deltaTime;
			if(del >= 0.5f){
				foreach(var endmagic in play_system.monster_target)
				{
					Debug.Log("죽어라!");
					endmagic.GetComponent<player>().hp_ -= active_damage;
				}
				Destroy(gameObject);
				one = false;
			}
		}
	}
}
