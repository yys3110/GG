using UnityEngine;
using System.Collections;
// 혼란(Confuse) active : 3칸 내의 적군은 1턴간 피아구분 불가
public class confuse_active : MonoBehaviour {
	public GameObject range_collider;
	public GameObject [] monster_object;
	public GameObject debuff;
	public int range = 3;
	public int turn = 1;
	bool one_for = true;
	float del = 0.1f;

	// Use this for initialization
	void Start () {
		hexagon.move_end = false;
		range_collider.GetComponent<range_collider>().range_ = range;
		Instantiate(range_collider,transform.position - new Vector3(0,5,0),range_collider.transform.rotation);
		monster_object = GameObject.FindGameObjectsWithTag("monster");
	}
	
	// Update is called once per frame
	void Update () {
		del -= Time.deltaTime;
		if(del <=0){
			if(one_for == true){
				for(int i=0; i< monster_object.Length; i ++){
					if(monster_object[i].GetComponent<monster>().range_collider == true){
						GameObject debuff_ = Instantiate(debuff,transform.position, debuff.transform.rotation) as GameObject;
						debuff_.transform.parent = monster_object[i].transform;
						debuff_.GetComponent<confuse_active_debuff>().turn = turn;
						Debug.Log("confuse ok");
					}
				}
				one_for = false;
			}
			hexagon.move_end = true;
			transform.parent.GetComponent<player>().wait_();
			Destroy(gameObject);
		}
	}
}
