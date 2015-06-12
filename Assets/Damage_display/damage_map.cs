using UnityEngine;
using System.Collections;

public class damage_map : MonoBehaviour {
	float del = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		transform.position += new Vector3(0,1,0) *2f* Time.deltaTime;
		if(del >= 0.5f){
			GetComponent<SpriteRenderer>().color -= new Color(0,0,0,1f) * Time.deltaTime;
			Destroy(gameObject,2f);
		}

	
	}
}
