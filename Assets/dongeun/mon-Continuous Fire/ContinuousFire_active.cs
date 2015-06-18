using UnityEngine;
using System.Collections;
// 4칸 내의 적에서 50% 추가피해(2턴)
public class ContinuousFire_active : MonoBehaviour {
	public int turn_cooltime;
	public GameObject Continuous_range;
	public int range_collider; //collider프리팹 범위
	//다이스 소환
	public GameObject[] dice_;
	public int dice_num;

	int attack_damage = 0;
	GameObject attack_dice;
	GameObject dice_object;

	// Use this for initialization
	void Start () {
		//collider프리팹 소환
		Camera.main.GetComponent<play_system>().dice_system.SetActive(true);
		dice_object = Instantiate(dice_[dice_num],new Vector3(182.4f,0.5f,-2.75f),new Quaternion(0,0,0,0)) as GameObject;
		dice_object.GetComponent<skill_dice>().skill_caster = transform.parent.transform.gameObject;
		dice_object.GetComponent<skill_dice>().OnMouseDown();

	}
	
	// Update is called once per frame
	void Update () {
		if(monster.skill_active == 1){
			attack_damage = transform.parent.transform.gameObject.GetComponent<monster>().temp_skill_dice_num/2;
			Debug.Log (attack_damage);
			play_system.skill_cast = true;
			Continuous_range.GetComponent<range_collider>().range_ = range_collider;
			Instantiate(Continuous_range,new Vector3(transform.position.x,0,transform.position.z),Continuous_range.transform.rotation);
			transform.position = new Vector3(transform.position.x,0,transform.position.z);
		
			transform.GetComponent<SphereCollider>().radius += 0.5F;
			
			if(transform.GetComponent<SphereCollider>().radius >=30)
			{
				transform.GetComponent<SphereCollider>().radius = 0;
				hexagon.move_end = true;
				play_system.skill_cast = false;
				Camera.main.GetComponent<play_system>().dice_system.SetActive(false);
				monster.skill_active = 0;
				transform.parent.gameObject.GetComponent<monster>().wait_();
				Destroy(gameObject);
			}
		}
		

	}
	void OnTriggerEnter(Collider coll){

		if(coll.gameObject.tag == "player" && coll.gameObject.GetComponent<player>().range_collider == true){
			player Explosion = coll.GetComponent<player>();
			Explosion.HP_system(attack_damage,false,transform.parent.gameObject,1);
		}
	}
}