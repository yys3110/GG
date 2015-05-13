using UnityEngine;
using System.Collections;

public class monster_guide : MonoBehaviour {

	public GameObject monster;
	public GameObject [] hex_collider;
	public float [] Dis_value = new float[6];
	public float min_value =10000;
	public int min_num =0;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i=0; i<6; i ++)
		{
			Dis_value[i] = Vector3.Distance (target.transform.position,hex_collider[i].transform.position);

			Ray ray = new Ray(hex_collider[i].transform.position ,hex_collider[i].transform.up *-1 );
			RaycastHit hit;

			if(Physics.Raycast(ray , out hit , Mathf.Infinity) && hit.collider.gameObject.tag == "hexagon")
			{
				if(hit.collider.GetComponent<hexagon>().hexagon_unit_bool == true){
				Dis_value[i] = 10000;
				}
			}

			if(min_value > Dis_value[i])
			{
				min_value = Dis_value[i];
				min_num = i;
			}
		}
		monster.GetComponent<monster>().move_pos = hex_collider[min_num].transform.position;
		monster.GetComponent<monster>().move_bool = true;
		Destroy(gameObject);

	
	}
}
