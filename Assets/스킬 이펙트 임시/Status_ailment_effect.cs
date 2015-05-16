using UnityEngine;
using System.Collections;

public class Status_ailment_effect : MonoBehaviour {
	public Texture [] tex_;
	public float speed_del;
	public float del =0;
	public int tex_num =0;
	public bool live = true;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = tex_[0];
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(del >= speed_del){
			tex_num ++;
			if(tex_num > 2){
				tex_num =0;
			}
			GetComponent<Renderer>().material.mainTexture = tex_[tex_num];
			del = 0;
		}
		if(live == false){
			float dey_time =1;
			dey_time -= Time.deltaTime;
			GetComponent<Renderer>().material.color -= new Color(0,0,0,1) * Time.deltaTime;
			Destroy(gameObject,1);

		}
	}
}
