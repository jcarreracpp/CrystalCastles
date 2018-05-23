using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public string user = "";

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		user += Input.inputString;

		if(user.Contains("78965")) {
			Debug.Log("Fireball");
			user = "";
		}
		if (user.Contains("236589")) {
			Debug.Log("Knockback Wave");
            user = "";
        }
		if (user.Contains("4789614563"))
        {
			Debug.Log("Mud Wall");
            user = "";
        }
		if (user.Contains("1458936587159"))
        {
			Debug.Log("Chain Lightning");
            user = "";
        }
		if (user.Contains("759153751953"))
        {
			Debug.Log("Air Bomb");
            user = "";
        }
		if (user.Contains("1258723698"))
        {
            Debug.Log("Firewall");
            user = "";
        }
		if (user.Contains("15986159863578435784"))
        {
            Debug.Log("Ice Lance");
            user = "";
        }
		if (user.Contains("7894561238741289632"))
        {
			Debug.Log("Geoslow");
            user = "";
        }

	}
}
