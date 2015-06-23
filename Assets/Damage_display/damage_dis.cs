using UnityEngine;
using System.Collections;

public class damage_dis : MonoBehaviour {
	public int damage =0; // 데미지 표기를 위한 수
	int pow_int = 3;
	public Sprite [] sprite_;
	public GameObject [] number_object;
	public bool stop_while = false;
	public int array_display =0;
	float del =0;
	bool array_bool = true;
	public GameObject unit_info;

	// Use this for initialization
	void Start () {
		transform.position += new Vector3(0,5+array_display*5,-0.2f);
		if(damage !=0){
			for(int i =0; i < number_object.Length; i++){
				number_object[i].GetComponent<SpriteRenderer>().sprite = sprite_[damage/(int)(Mathf.Pow(10,(float)(i)))%10];
			}
		}
		else{
			number_object[0].GetComponent<SpriteRenderer>().sprite = sprite_[0];
			number_object[1].GetComponent<SpriteRenderer>().sprite = null;
			number_object[2].GetComponent<SpriteRenderer>().sprite = null;
			number_object[3].GetComponent<SpriteRenderer>().sprite = null;

		}

		while(stop_while == false && damage!=0){
			if(damage < Mathf.Pow(10,(int)(pow_int))){
				number_object[pow_int].GetComponent<SpriteRenderer>().sprite = null;
				pow_int --;
			}
			else{
				stop_while = true;
				number_object[pow_int+1].GetComponent<SpriteRenderer>().sprite = sprite_[10];
			}
		}
		array_display ++;
	}
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		transform.position += new Vector3(0,1,0) *2f* Time.deltaTime;
		if(del >= 1f){
			for(int i = 0; i <number_object.Length; i++ ){
				number_object[i].GetComponent<SpriteRenderer>().color -= new Color(0,0,0,1) * Time.deltaTime;
			}
			if(array_bool == true){
				if(unit_info.GetComponent<player>() == true)
					unit_info.GetComponent<player>().array_display --;
				if(unit_info.GetComponent<monster>() == true)
					unit_info.GetComponent<monster>().array_display --;
				array_bool = false;
			}
			Destroy(gameObject,2f);
		}
	}
}
