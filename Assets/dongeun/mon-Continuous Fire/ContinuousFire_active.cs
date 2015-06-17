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

	// Use this for initialization
	void Start () {
		//collider프리팹 소환
		//play_system.skill_cast = true;
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
		Continuous_range.GetComponent<range_collider>().range_ = range_collider;
		Instantiate(Continuous_range,transform.position,Continuous_range.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
			transform.GetComponent<SphereCollider>().radius += 0.5F;
			
			if(transform.GetComponent<SphereCollider>().radius >=30)
			{
				transform.GetComponent<SphereCollider>().radius = 0;
				hexagon.move_end = true;
				//play_system.skill_cast = false;
				//transform.parent.gameObject.GetComponent<monster>().wait_();
				Destroy(gameObject);
			}
		

	}
	void OnTriggerEnter(Collider coll){

		if(coll.gameObject.tag == "player" && coll.gameObject.GetComponent<player>().range_collider == true){
			Debug.Log("들어오냐??");
			player Explosion = coll.GetComponent<player>();
			Explosion.HP_system(1,false,transform.parent.gameObject,1);
		}
	}
}