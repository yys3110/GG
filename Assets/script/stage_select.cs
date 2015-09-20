using UnityEngine;
using System.Collections;

public class stage_select : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(10,10,100,40),"1 STAGE"))
		{
			PlayerPrefs.SetInt("stage",1);
			Application.LoadLevel("inGame");
		}
		if(GUI.Button(new Rect(10,50,100,40),"2 STAGE"))
		{
			PlayerPrefs.SetInt("stage",2);
			Application.LoadLevel("inGame");
		}
		if(GUI.Button(new Rect(10,90,100,40),"3 STAGE"))
		{
			PlayerPrefs.SetInt("stage",3);
			Application.LoadLevel("inGame");
		}
		if(GUI.Button(new Rect(10,140,100,40),"4 STAGE"))
		{
			PlayerPrefs.SetInt("stage",4);
			Application.LoadLevel("inGame");
		}
		if(GUI.Button(new Rect(10,180,100,40),"5 STAGE"))
		{
			PlayerPrefs.SetInt("stage",5);
			Application.LoadLevel("inGame");
		}
		if(GUI.Button(new Rect(10,220,100,40),"6 STAGE"))
		{
			PlayerPrefs.SetInt("stage",6);
			Application.LoadLevel("inGame");
		}
		if(GUI.Button(new Rect(10,260,100,40),"7 STAGE"))
		{
			PlayerPrefs.SetInt("stage",7);
			Application.LoadLevel("inGame");
		}
		if(GUI.Button(new Rect(10,300,100,40),"Test STAGE - MOUNT"))
		{
			PlayerPrefs.SetInt("stage", 8);
			Application.LoadLevel("inGame");
		}
	}
}
