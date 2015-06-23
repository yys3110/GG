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
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 20)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[0];
						hex_[i].GetComponent<hexagon>().hexagon_type = 0;
					}
				}
				if(random_ >=20 && random_ < 30)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[1];
						hex_[i].GetComponent<hexagon>().hexagon_type = 1;
					}
				}
				if(random_ >=30 && random_ < 45)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[4];
						hex_[i].GetComponent<hexagon>().hexagon_type = 4;
					}
				}
				if(random_ >=45 && random_ < 95)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[5];
						hex_[i].GetComponent<hexagon>().hexagon_type = 5;
					}
				}
				if(random_ >=95 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[6];
						hex_[i].GetComponent<hexagon>().hexagon_type = 6;
					}
				}
				
			}
			if(stage == 2)
			{
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 15)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[0];
						hex_[i].GetComponent<hexagon>().hexagon_type = 0;
					}
				}
				if(random_ >=15 && random_ < 30)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[1];
						hex_[i].GetComponent<hexagon>().hexagon_type = 1;
					}
				}
				if(random_ >=30 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[2];
						hex_[i].GetComponent<hexagon>().hexagon_type = 2;
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[6];
						hex_[i].GetComponent<hexagon>().hexagon_type = 6;
					}
				}
			}
			if(stage == 3)
			{
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 10)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[1];
						hex_[i].GetComponent<hexagon>().hexagon_type = 1;
					}
				}
				if(random_ >=10 && random_ < 30)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[2];
						hex_[i].GetComponent<hexagon>().hexagon_type = 2;
					}
				}
				if(random_ >=30 && random_ < 35)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[5];
						hex_[i].GetComponent<hexagon>().hexagon_type = 5;
					}
				}
				if(random_ >=35 && random_ < 60)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[6];
						hex_[i].GetComponent<hexagon>().hexagon_type = 6;
					}
				}
				if(random_ >= 60 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[7];
						hex_[i].GetComponent<hexagon>().hexagon_type = 7;
					}
				}
				
			}
			if(stage == 4)
			{
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 30)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[3];
						hex_[i].GetComponent<hexagon>().hexagon_type = 3;
					}
				}
				if(random_ >=30 && random_ < 40)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[4];
						hex_[i].GetComponent<hexagon>().hexagon_type = 4;
					}
				}
				if(random_ >=40 && random_ < 50)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[6];
						hex_[i].GetComponent<hexagon>().hexagon_type = 6;
					}
				}
				if(random_ >=50 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[8];
						hex_[i].GetComponent<hexagon>().hexagon_type = 8;
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[9];
						hex_[i].GetComponent<hexagon>().hexagon_type = 9;
					}
				}
				
			}
			if(stage == 5)
			{
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 25)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[0];
						hex_[i].GetComponent<hexagon>().hexagon_type = 0;
					}
				}
				if(random_ >=25 && random_ < 60)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[1];
						hex_[i].GetComponent<hexagon>().hexagon_type = 1;
					}
				}
				if(random_ >=60 && random_ < 80)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[2];
						hex_[i].GetComponent<hexagon>().hexagon_type = 2;
					}
				}
				if(random_ >=80 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[5];
						hex_[i].GetComponent<hexagon>().hexagon_type = 5;
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[6];
						hex_[i].GetComponent<hexagon>().hexagon_type = 6;
					}
				}
				
			}
			if(stage == 6)
			{
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 10)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[0];
						hex_[i].GetComponent<hexagon>().hexagon_type = 0;
					}
				}
				if(random_ >=10 && random_ < 25)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[1];
						hex_[i].GetComponent<hexagon>().hexagon_type = 1;
					}
				}
				if(random_ >=25 && random_ < 50)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[2];
						hex_[i].GetComponent<hexagon>().hexagon_type = 2;
					}
				}
				if(random_ >=50 && random_ < 70)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[5];
						hex_[i].GetComponent<hexagon>().hexagon_type = 5;
					}
				}
				if(random_ >=70 && random_ < 90)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[6];
						hex_[i].GetComponent<hexagon>().hexagon_type = 6;
					}
				}
				if(random_ >=90 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[9];
						hex_[i].GetComponent<hexagon>().hexagon_type = 9;
					}
				}
			}
			if(stage == 7)
			{
				random_ = Random.Range(0,100);
				if(random_ >=0 && random_ < 10)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[0];
						hex_[i].GetComponent<hexagon>().hexagon_type = 0;
					}
				}
				if(random_ >=10 && random_ < 20)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[1];
						hex_[i].GetComponent<hexagon>().hexagon_type = 1;
					}
				}
				if(random_ >=20 && random_ < 55)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[2];
						hex_[i].GetComponent<hexagon>().hexagon_type = 2;
					}
				}
				if(random_ >=55 && random_ < 60)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[3];
						hex_[i].GetComponent<hexagon>().hexagon_type = 3;
					}
				}
				if(random_ >=60 && random_ < 65)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[4];
						hex_[i].GetComponent<hexagon>().hexagon_type = 4;
					}
				}
				if(random_ >=65 && random_ < 80)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[5];
						hex_[i].GetComponent<hexagon>().hexagon_type = 5;
					}
				}
				if(random_ >=80 && random_ < 95)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[6];
						hex_[i].GetComponent<hexagon>().hexagon_type = 6;
					}
				}
				if(random_ >=95 && random_ < 100)
				{
					for(int i = 0 ; i<3 ; i++)
					{
						hex_[i].GetComponent<Renderer>().material.mainTexture = hex_tex[7];
						hex_[i].GetComponent<hexagon>().hexagon_type = 7;
					}
				}
			}
			random_map = false;
		}

	}
		
}
