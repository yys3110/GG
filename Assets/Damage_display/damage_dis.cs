using UnityEngine;
using System.Collections;

public class damage_dis : MonoBehaviour {
	public int damage =0; // 데미지 표기를 위한 수
	int pow_int = 3;
	public Sprite [] sprite_;
	public GameObject [] number_object;
	public bool stop_while = false;
	float del =0;

	// Use this for initialization
	void Start () {
		transform.position += new Vector3(0,5,2);
		for(int i =0; i < number_object.Length; i++){
			number_object[i].GetComponent<SpriteRenderer>().sprite = sprite_[damage/(int)(Mathf.Pow(10,(float)(i)))%10];
		}

		while(stop_while == false){
			if(damage < Mathf.Pow(10,(int)(pow_int))){
				number_object[pow_int].GetComponent<SpriteRenderer>().sprite = null;
				pow_int --;
			}
			else{
				stop_while = true;
				number_object[pow_int+1].GetComponent<SpriteRenderer>().sprite = sprite_[10];
			}
		}
	}
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		transform.position += new Vector3(0,1,0) *2f* Time.deltaTime;
		if(del >= 1f){
			for(int i = 0; i <number_object.Length; i++ ){
				number_object[i].GetComponent<SpriteRenderer>().color -= new Color(0,0,0,1) * Time.deltaTime;
			}
			Destroy(gameObject,2f);
		}
	}
}
