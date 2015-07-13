using UnityEngine;
using System.Collections;
// 기동력 내의 적을 밀어내고 자리차지+3의 데미지(2턴)
public class Flight_active : MonoBehaviour {
	public GameObject collider_;
	public GameObject LootAt_;
	public GameObject debuff;
	public GameObject caster;
	// Use this for initialization
	void Start () {
		caster = transform.parent.transform.gameObject;
		hexagon.move_end = false;
		Destroy(collider_,0.1f);
	}
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray , out hit , Mathf.Infinity)){
			if(hit.collider.gameObject.CompareTag("monster")&& hit.collider.GetComponent<monster>().range_collider == true){
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					Debug.Log("monster click");
					LootAt_.transform.LookAt(hit.collider.gameObject.transform.position);
					GameObject debuff_object = Instantiate(debuff,hit.collider.transform.position,debuff.transform.rotation) as GameObject;
					debuff_object.transform.parent = hit.collider.transform;
					debuff_object.GetComponent<Flight_active_debuff>().rotate_ = LootAt_.transform.localEulerAngles;
					debuff_object.GetComponent<Flight_active_debuff>().caster = caster;
					Destroy(gameObject);
					hexagon.move_end = true;
					//hexagon.move_end = true;
				}
			}
		}
	}
}
