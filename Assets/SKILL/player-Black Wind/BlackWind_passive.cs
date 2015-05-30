using UnityEngine;
using System.Collections;
// 흑풍(Black Wind) : 피격 된 데미지의 20%로 반격
public class BlackWind_passive : MonoBehaviour {
	public int hp_max;
	public int hp;

	// Use this for initialization
	void Start () {
		hp_max = transform.parent.GetComponent<player>().hp_max ;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
