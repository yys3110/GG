using UnityEngine;
using System.Collections;

public class GOD_SWORD : MonoBehaviour  {
	public Texture2D [] cursor;
	static public bool god_bool = true;
	public int damage;
	public bool critical;


	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursor[0],Vector2.zero,CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
		if(god_bool == false){
			Cursor.SetCursor(cursor[1],Vector2.zero,CursorMode.Auto);
			Destroy(gameObject);
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray , out hit ,Mathf.Infinity)){
			if(Input.GetAxis("Mouse ScrollWheel")>0){
				if(hit.collider.GetComponent<player>() == true){
					hit.collider.GetComponent<player>().HP_system(damage,critical,null);
				}
				if(hit.collider.GetComponent<monster>() == true){
					hit.collider.GetComponent<monster>().HP_system(damage,critical,null);
				}
			}
			if(Input.GetAxis("Mouse ScrollWheel")<0){
				if(hit.collider.GetComponent<player>() == true){
					hit.collider.GetComponent<player>().HP_system(0,critical,null);
					hit.collider.GetComponent<player>().hp_ +=1;
				}
				if(hit.collider.GetComponent<monster>() == true){
					hit.collider.GetComponent<monster>().HP_system(0,critical,null);
					hit.collider.GetComponent<monster>().hp_ +=1;
				}
			}
		}
	}	
}
