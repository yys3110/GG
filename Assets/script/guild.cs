using UnityEngine;
using System.Collections;

public class guild : MonoBehaviour {

	public GameObject player;
	public float guide_rotate;
	public bool one_rotate = true;
	public Vector3 end_pos;
	public GameObject guide_;
	//public static int guide_num;
	public bool not_hit = true;
	public float mouse_distance_z;
	public float mouse_distance_x;
	// Use this for initialization
	void Start () {
		GameObject group = GameObject.FindWithTag ("guide_group");
		transform.transform.parent = group.transform;
		transform.LookAt(end_pos);
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay (new Vector3 (transform.position.x, transform.position.y-1, transform.position.z), transform.forward * 10.0f, Color.red);
		if(one_rotate == true)
		{
		float distance= Vector3.Distance (transform.position,end_pos);
		guide_rotate = transform.localEulerAngles.y;

		if(guide_rotate >=0 && guide_rotate < 60)
		transform.localEulerAngles = new Vector3 (0,30,0);
		if(guide_rotate >=60 && guide_rotate < 120)
		transform.localEulerAngles = new Vector3 (0,90,0);
		if(guide_rotate >=120 && guide_rotate < 180)
		transform.localEulerAngles = new Vector3 (0,150,0);
		if(guide_rotate >=180 && guide_rotate < 240)
		transform.localEulerAngles = new Vector3 (0,210,0);
		if(guide_rotate >=240 && guide_rotate < 300)
		transform.localEulerAngles = new Vector3 (0,270,0);
		if(guide_rotate >=300 && guide_rotate < 360)
		transform.localEulerAngles = new Vector3 (0,330,0);
		
		//Ray ray = new Ray(transform.position,transform.forward);
		Ray ray = new Ray (new Vector3 (transform.position.x, transform.position.y -1, transform.position.z), transform.forward);
		RaycastHit hit;
		bool hit_hex = false;
		if(Physics.Raycast(ray, out hit , 10))
		{
			
			if(hit.collider.gameObject.tag == "hexagon" )
			{
				hit_hex = true;
				bool hex_guide_bool = hit.collider.gameObject.GetComponent<hexagon>().guide_bool;
				if(hex_guide_bool == false)
				{
				
				if(distance >5f)
				{
				player = GameObject.FindWithTag ("player");
				//player.GetComponent<player>().move_guide_pos[guide_num] = hit.collider.gameObject.transform.position;
			//	guide_num ++;
				Vector3 next_guide_pos = hit.collider.gameObject.transform.position;
				hit.collider.gameObject.GetComponent<hexagon>().guide_bool = true;
				Instantiate (guide_,new Vector3 (next_guide_pos.x,next_guide_pos.y +1 ,next_guide_pos.z),transform.rotation);
				one_rotate = false;
				}
				}
			}
			
		}
		if(hit_hex == false)
		{
		not_hit = hit_hex;
		if(mouse_distance_z <0)
		{
			if(mouse_distance_x >0)
			transform.localEulerAngles += new Vector3(0, -60, 0);
			if(mouse_distance_x <0)
			transform.localEulerAngles += new Vector3(0, +60, 0);
			Debug.Log("dis ++" +transform.localEulerAngles.y);
		}
		if(mouse_distance_z >0)
		{
			if(mouse_distance_x >0)
			transform.localEulerAngles += new Vector3(0, 60, 0);
			if(mouse_distance_x <0)
			transform.localEulerAngles += new Vector3(0, -60, 0);
			Debug.Log("dis --"+transform.localEulerAngles.y);
		}
		
		
		}
		
		
		}
	
	}
}
