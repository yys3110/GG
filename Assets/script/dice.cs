using UnityEngine;
using System.Collections;

public class dice : MonoBehaviour {
	public bool dice_roll = false;
	public int dice_number; // 몇 면체의 주사위 인가
	public int dice_num;
	public int collider_num;
	public Vector3 velocity_dice;
	public float velocityd;
	public bool camera_move_bool = false;
	public GameObject dice_camera;
	public float del;
	//스킬 관련
	public bool skill_On = false;
	public GameObject skill_caster;
	Rect go_rect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(dice_roll == true){
			del += Time.deltaTime;
			dice_num = (dice_number+1) - collider_num;
			velocity_dice = this.GetComponent<Rigidbody>().velocity;
			velocityd = this.GetComponent<Rigidbody>().velocity.magnitude;
			//if((velocity_dice.x ==0 && velocity_dice.y ==0 && velocity_dice.z ==0)|| del>=5){
				if(velocityd <= 0.0f){
				play_system.play_dice_num = dice_num;

				if(play_system.turn == 1){
					camera_move_bool = true;
				}
				if(play_system.turn == 2){
					if(skill_On == false){
						dice_camera = GameObject.FindWithTag ("ui_camera");
						dice_camera.transform.localPosition = new Vector3(0,8.92f,-9.18f);
						transform.localPosition = new Vector3(0.06001282f,1,-4.0f);
						go_rect = new Rect (0,0,0,0);
						play_system.dice_active_num ++;
						Destroy(gameObject);
					}
					if(skill_On == true){
						dice_camera = GameObject.FindWithTag ("ui_camera");
						dice_camera.transform.localPosition = new Vector3(0,8.92f,-9.18f);
						transform.localPosition = new Vector3(0.06001282f,1,-4.0f);
						go_rect = new Rect (0,0,0,0);
						skill_caster.transform.parent.GetComponent<monster>().add_damage = dice_num;
						monster.skill_active++;
						skill_On = false;
						Destroy(gameObject);
					}

				}
				del =0;
				dice_roll = false;
			}
		}
		if(camera_move_bool == true){
			dice_camera = GameObject.FindWithTag ("ui_camera");
			if(dice_number == 0)
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x,240,transform.localEulerAngles.z);
			if(dice_camera != null)
			dice_camera.transform.position = Vector3.MoveTowards
			(dice_camera.transform.position,new Vector3(this.transform.position.x,4,this.transform.position.z-3),Time.deltaTime*10);
			float distance = Vector3.Distance(new Vector3(this.transform.position.x,4,this.transform.position.z-3),dice_camera.transform.position);
			if(distance == 0){
				go_rect = new Rect (300,200,100,100);
				camera_move_bool = false;
			}
		}

		if(play_system.turn == 2 && play_system.monster_one_dice_bool == true){
			OnMouseDown();
			if(skill_On == false)
			play_system.monster_one_dice_bool = false;
			Debug.Log("monster dice roll");
		}

	}
	void OnMouseDown(){
		if(dice_roll == false){
			this.GetComponent<Rigidbody>().velocity += new Vector3 (0,10,5);
			int random_y = Random.Range(-100,100);
			int random_x= Random.Range(-100,100);
			this.GetComponent<Rigidbody>().AddTorque(new Vector3(random_x,random_y,0));
			dice_roll = true;
		}

	}

	void OnGUI(){
		if(play_system.turn == 1){
			if(GUI.RepeatButton(go_rect,"GO")){
				dice_camera.transform.localPosition = new Vector3(0,8.92f,-9.18f);
				transform.localPosition = new Vector3(0.06001282f,1,-4.0f);
				play_system.dice_active_num ++;
				go_rect = new Rect (0,0,0,0);
				Destroy(gameObject);
			}
		}
	}
}
