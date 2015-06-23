using UnityEngine;
using System.Collections;

public class HP_BAR : MonoBehaviour {
	public GameObject hp_bar;
	public float max_hp;
	public float hp_;
	public float move_bar;
	public float scale;
	public float r,g,b;
	// Use this for initialization
	void Start () {
		if(transform.parent.GetComponent<player>() == true){
			max_hp = transform.parent.GetComponent<player>().hp_max;
		}
		else if(transform.parent.GetComponent<monster>() == true){
			max_hp = transform.parent.GetComponent<monster>().hp_max;
		}
		hp_ = max_hp;
		scale = hp_bar.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void HP_HUD(float hp){
		hp_ = hp;
		if(hp_>= max_hp)
			hp_ = max_hp;
		if(hp_ <=0)
			hp_ =0;

		move_bar = hp_ / (max_hp * 1);
		hp_bar.transform.localPosition = new Vector3((move_bar * 2.4f)-2.4f,hp_bar.transform.localPosition.y,hp_bar.transform.localPosition.z);
		hp_bar.transform.localScale = new Vector3(scale*move_bar,hp_bar.transform.localScale.y,hp_bar.transform.localScale.z);
		if(g >=1){
			r = 2*(1- move_bar);
			hp_bar.GetComponent<Renderer>().material.color = new Color(r,g,b);
		}
		if(r >=1){
			g = move_bar *2;
			hp_bar.GetComponent<Renderer>().material.color = new Color(r,g,b);
		}
	}
}
