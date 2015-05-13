using UnityEngine;
using System.Collections;

public class guide_system : MonoBehaviour {
	public GameObject guide;
	public GameObject guide_cube;
	public Vector3 mouse_distance;
	public GameObject [] hex_collider;
	public float[] dis_value ;
	public float min_dis = 1000;
	public int min_num =0;
	bool one_ray = true;
	public bool [] one_collider = new bool[6];
	public bool stop_guide = false;
	public int guide_num =0;
	public GameObject player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		for(int i =0; i <6; i++)
		{
			Debug.DrawRay (new Vector3 (hex_collider[i].transform.position.x, hex_collider[i].transform.position.y, hex_collider[i].transform.position.z), transform.up * -5.0f, Color.red);
		}
		if(one_ray == true)
		{
			for(int i =0; i<6; i++)
			{
				one_collider [i] = false;
				Ray ray = new Ray(hex_collider[i].transform.position,transform.up *-1);
				RaycastHit hit;
				if(Physics.Raycast(ray , out hit ,10f))
				{
					if(hit.collider.gameObject.tag == "guide_collider")
					{
						one_collider[i] = false;
					}
					if(hit.collider.gameObject.tag == "hexagon")
					{
						if(hit.collider.gameObject.GetComponent<hexagon>().mouse_over_bool == true)
						stop_guide = true;
						one_collider[i] = true;
						if(hit.collider.gameObject.GetComponent<hexagon>().collider_bool == true)
						one_collider[i] = false;
						dis_value[i] = Vector3.Distance(mouse_distance,hit.collider.gameObject.transform.position);
						hit.collider.gameObject.GetComponent<hexagon>().collider_bool = true;
						if(hit.collider.GetComponent<hexagon>().hexagon_unit_bool == true){
							one_collider[i] = false;
						}
					}
				}
				if(one_collider[i] == false)
				dis_value[i] = 1000;
				if(min_dis >= dis_value[i])
				{
					min_dis = dis_value[i];
					min_num = i;
				}
			}
			if(min_dis == 0)
			{
				one_ray = false;
				//player = GameObject.FindWithTag ("player"); 보류 

				player.GetComponent<player>().guide_num = guide_num;
				guide_num = 0;
			}
			else if(min_dis > 0 && min_dis != 1000 && stop_guide != true)
			{
				//player = GameObject.FindWithTag ("player"); 보류
				player = player;
				player.GetComponent<player>().move_guide_pos[guide_num] = hex_collider[min_num].transform.position;
				guide_num ++;
				guide.GetComponent<guide_system>().guide_num = guide_num;
				guide.GetComponent<guide_system>().min_dis = 1000;
				GameObject guide_ch1 = Instantiate(guide_cube,new Vector3(hex_collider[min_num].transform.position.x,1,hex_collider[min_num].transform.position.z),transform.rotation) as GameObject;
				GameObject guide_ch2= Instantiate(guide,new Vector3 (hex_collider[min_num].transform.position.x,1,hex_collider[min_num].transform.position.z),transform.rotation)as GameObject ;
				GameObject guide_guoup = GameObject.FindWithTag ("guide_group");
				guide_ch1.transform.parent = guide_guoup.transform;
				guide_ch2.transform.parent = guide_guoup.transform;
				//min_dis =0;
			}
			one_ray = false;
			//Destroy(transform.gameObject);
		}


	
	}
}
