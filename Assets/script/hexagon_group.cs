using UnityEngine;
using System.Collections;

public class hexagon_group : MonoBehaviour {

	public Texture[] hex_tex;
	public GameObject [] hex_;
	public int random_ ;
	public static bool random_map_start = true;
	public bool random_map = true;
	public bool one_random = true;
	public int stage;
	public Texture[] map_tex;

	// Use this for initialization
	void Start () {
	stage = PlayerPrefs.GetInt("stage");
	}
	
	// Update is called once per frame
	void Update () {

		if(one_random == true && random_map_start == true )
		{
			random_map = true;
			one_random = false;
		}
		if(random_map_start == false)
		{
			one_random = true;
		}
		if(random_map == true)
		{
			if(stage == 1)
			{
				map_tex = new Texture[3];
				map_tex[0] = hex_tex[3];
				map_tex[1] = hex_tex[4];
				map_tex[2] = hex_tex[0];
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 70)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[0];
					}
				}
				if(random_ >=70 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[1];
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[2];
					}
				}
				
			}
			if(stage == 2)
			{
				map_tex = new Texture[3];
				map_tex[0] = hex_tex[0];
				map_tex[1] = hex_tex[4];
				map_tex[2] = hex_tex[5];
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 80)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[0];
					}
				}
				if(random_ >=80 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[1];
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[2];
					}
				}
				
			}
			if(stage == 3)
			{
				map_tex = new Texture[4];
				map_tex[0] = hex_tex[5];
				map_tex[1] = hex_tex[0];
				map_tex[2] = hex_tex[1];
				map_tex[3] = hex_tex[2];
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 40)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[0];
					}
				}
				if(random_ >=40 && random_ < 70)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[1];
					}
				}
				if(random_ >=70 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[2];
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[3];
					}
				}
				
			}
			if(stage == 4)
			{
				map_tex = new Texture[3];
				map_tex[0] = hex_tex[1];
				map_tex[1] = hex_tex[2];
				map_tex[2] = hex_tex[3];
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 60)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[0];
					}
				}
				if(random_ >=60 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[1];
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[2];
					}
				}
				
			}
			if(stage == 5)
			{
				map_tex = new Texture[4];
				map_tex[0] = hex_tex[0];
				map_tex[1] = hex_tex[3];
				map_tex[2] = hex_tex[4];
				map_tex[3] = hex_tex[1];
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 50)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[0];
					}
				}
				if(random_ >=50 && random_ < 70)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[1];
					}
				}
				if(random_ >=70 && random_ < 95)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[2];
					}
				}
				if(random_ >=95 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[3];
					}
				}
				
			}
			if(stage == 6)
			{
				map_tex = new Texture[4];
				map_tex[0] = hex_tex[0];
				map_tex[1] = hex_tex[3];
				map_tex[2] = hex_tex[4];
				map_tex[3] = hex_tex[5];
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 60)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[0];
					}
				}
				if(random_ >=60 && random_ < 75)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[1];
					}
				}
				if(random_ >=75 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[2];
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[3];
					}
				}
				
			}
			if(stage == 7)
			{
				map_tex = new Texture[3];
				map_tex[0] = hex_tex[0];
				map_tex[1] = hex_tex[4];
				map_tex[2] = hex_tex[3];
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 60)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[0];
					}
				}
				if(random_ >=60 && random_ < 85)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[1];
					}
				}
				if(random_ >=85 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = map_tex[2];
					}
				}
				
			}
			random_map = false;
		}

	}
		
}
