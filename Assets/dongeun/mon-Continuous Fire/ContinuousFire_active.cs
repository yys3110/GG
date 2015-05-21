using UnityEngine;
using System.Collections;

public class ContinuousFire_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject Continuous_range;
	public int range_collider; //collider프리팹 범위
	//다이스 소환
	public GameObject[] dice_;
	public int dice_num;
	// Use this for initialization
	void Start () {
		//다이스 소환
		Camera.main.GetComponent<play_system>().dice_systemOn();
		//dice_[dice_num].GetComponent<dice>().skill_On = true;
		//dice_[dice_num].GetComponent<dice>().skill_caster = this.gameObject;
		Instantiate(dice_[dice_num],new Vector3(182.4f,0.5f,-2.75f),dice_[dice_num].transform.rotation);
		//collider프리팹 소환
		Continuous_range.GetComponent<range_collider>().range_ = range_collider;
		Instantiate(Continuous_range,transform.position,Continuous_range.transform.rotation);
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if()//monster가 주사위를 던지고 if문 작동되야됨
		{
		transform.GetComponent<SphereCollider>().radius += 0.5F;
		if(transform.GetComponent<SphereCollider>().radius >=40)
		{
			Destroy(gameObject);
			hexagon.move_end = true;
		}
		}*/
	}
	void OnTriggerEnter(Collider coll){
		monster Explosion = coll.GetComponent<monster>();
		
		if(coll.gameObject.tag == "monster" && coll.gameObject.GetComponent<monster>().range_collider == true){
			Explosion.hp_--; // 다이스 던지고 주변 다이스데미지 50% 줘야됨
		}
	}
}