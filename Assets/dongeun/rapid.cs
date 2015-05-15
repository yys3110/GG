using UnityEngine;
using System.Collections;
//신속 스킬
public class rapid : MonoBehaviour {
	public int move_range = 3;

	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<player>().move_range += move_range;
		Destroy(gameObject);


	}
	
	// Update is called once per frame
	void Update () {

	}
}
