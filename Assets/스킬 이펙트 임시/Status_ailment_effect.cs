using UnityEngine;
using System.Collections;

public class Status_ailment_effect : MonoBehaviour {
	public bool live = true;
	public float del = 0;
	public float speed_del=0;
	public Texture [] tex_;
	public int num = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(del >=speed_del){
			GetComponent<Renderer>().material.mainTexture = tex_[num];
			num++;
			if(num >= tex_.Length)
			{
				num =0;
			}
			del = 0;
		}
		if(live == false){
			GetComponent<Renderer>().material.color -= new Color(0,0,0,1) * Time.deltaTime;
			Destroy(gameObject,1f);
		}
			
	
	}
}
