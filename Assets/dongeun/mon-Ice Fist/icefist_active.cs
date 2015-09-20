using UnityEngine;
using System.Collections;
//4칸 안에 한명에게 고정데미지 와 1턴간 행동불가 4칸은 몬스터의 게임오프젝트에 있는skill_range를 40으로 하고 사용
public class icefist_active : MonoBehaviour {
	public GameObject debuff;
	public int turn_cooltime; // 스킬 쿨타임
	public int ice; // 고정데미지
	public GameObject range_collider;
	float del = 0;
	// Use this for initialization
	void Start () {
		hexagon.move_end = false;
		GameObject range_ = Instantiate(range_collider,transform.position + new Vector3(0,-5,0),range_collider.transform.rotation) as GameObject;
		range_.GetComponent<range_collider>().range_ = 4;
	}
	
	// Update is called once per frame
	void Update () {
		del += Time.deltaTime;
		if(del >= 0.25f){
			for(int i =0; i < play_system.monster_target.Count; i++){
				if(play_system.monster_target[i].GetComponent<player>().range_collider == true){
					GameObject child = Instantiate(debuff,transform.position,debuff.transform.rotation) as GameObject;
					child.transform.parent = play_system.monster_target[i].transform;
					play_system.monster_target[i].GetComponent<player>().HP_system(ice,false,transform.parent.gameObject,1);
					break;
				}
			}
			hexagon.move_end = true;
			transform.parent.GetComponent<monster>().wait_();
			Destroy(gameObject);
		}

	}
}
