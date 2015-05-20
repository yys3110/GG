using UnityEngine;
using System.Collections;

public class range_collider : MonoBehaviour {
	public GameObject collider;
	public int range_;
	public float [] rotation_;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		for(int j =1; j<range_+1; j++){
			for(int i =0; i <6; i ++){
				GameObject object_ =  Instantiate(collider,transform.position,transform.rotation) as GameObject;
				object_.GetComponent<collider>().coll_num = j;
				object_.GetComponent<collider>().num = i;
				object_.transform.eulerAngles = new Vector3(0,rotation_[i],0);
				if(i == 1 || i == 4)
					object_.transform.position += object_.transform.forward *(10*j);
				else
					object_.transform.position += object_.transform.forward *(9*j);
				object_.transform.localScale = new Vector3(1,1,1);
			}
		}
		Destroy(gameObject);

	}
}
