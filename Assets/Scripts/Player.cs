using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private Stat health;
	[SerializeField]
	private Stat Mana;

	private void Awake()
	{
		health.Initialize ();
		Mana.Initialize ();
	}

	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			health.CurrentVal -= 5;
		}
		if(Input.GetKeyDown(KeyCode.W))
		{
			health.CurrentVal += 5;
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			Mana.CurrentVal -= 1;
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			Mana.CurrentVal += 1;
		}
	}

    public void modifyHealth(int i) {
        health.CurrentVal += i;
    }
}
