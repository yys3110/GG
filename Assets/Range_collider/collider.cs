using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {
	public int coll_num =0;
	public int num;
	public GameObject child;

	public GameObject coll;

	// Use this for initialization
	void Start () {
		if(num == 1 || num == 2 || num == 4|| num == 5){
			child.transform.eulerAngles += new Vector3(0,10,0);
			child.transform.localPosition = new Vector3 (0,0,0);
			child.transform.localScale = new Vector3 (1,1,coll_num*9);
			child.transform.position += child.transform.forward * coll_num*4.5f;
		}
		else{
			child.transform.localPosition = new Vector3 (0,0,0);
			child.transform.localScale = new Vector3 (1,1,coll_num*9);
			child.transform.position += child.transform.forward * coll_num*4.5f;
		}
		//if(transform.gameObject != null)
			Destroy(gameObject,0.1f);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
