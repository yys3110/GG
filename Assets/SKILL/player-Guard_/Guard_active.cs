using UnityEngine;
using System.Collections;
//호위(Guard) : 3칸 내의 아군 한명에게 한턴간 10의 피해를 막는 방어막 생성(3턴)
public class Guard_active : MonoBehaviour {
	public GameObject range_collider;
	public GameObject buff;
	public int range = 3;

	// Use this for initialization
	void Start () {
		play_system.skill_cast = true;
		hexagon.move_end = false;
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
		range_collider.GetComponent<range_collider>().range_ = range;
		Instantiate(range_collider,new Vector3(transform.position.x,0,transform.position.z),range_collider.transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit , Mathf.Infinity)){
			if(hit.collider.gameObject.tag == "player" && hit.collider.GetComponent<player>().range_collider == true){
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					GameObject player_child = Instantiate(buff,hit.transform.position,buff.transform.rotation) as GameObject;
					player_child.transform.parent = hit.collider.transform;
					//mon_child.transform.localScale += new Vector3(0.25f,0.25f,0.25f);
					transform.parent.GetComponent<player>().wait_();
					play_system.skill_cast = false;
					Destroy(gameObject);
				}
			}
		}
	}
}
