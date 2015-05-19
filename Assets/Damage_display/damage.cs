using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour {
	public int damage_dis =0; // 데미지 표기를 위한 수 
	float del =0;

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = System.Convert.ToString(damage_dis);
		transform.position += new Vector3(0,5,0);
	}

	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		transform.position += new Vector3(0,1,0) *2f* Time.deltaTime;
		if(del >= 1f){
			this.GetComponent<TextMesh>().color -= new Color(0,0,0,0.5f) * Time.deltaTime;
			Destroy(gameObject,2f);
		}
	
	
	}
}
