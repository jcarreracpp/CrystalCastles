using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private Stat health;
	[SerializeField]
	private Stat Mana;
	[SerializeField]
	private int money;

	private int[] availableMagics = new int[8];

	private void Awake()
	{
		Money = 0;
		health.Initialize ();
		Mana.Initialize ();

		for (int i = 0; i < 8; i++)
		{
			availableMagics[i] = 0;
		}
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

	public Stat Health
	{
		get{ return health;}
		set{ }
	}
	public int Money
	{
		get { return money; }
		set
		{
			this.money = value;
		}
	}
	public void modifyHealth(int i)
    {
        health.CurrentVal += i;
    }

    public void increaseHealth()
    {
        health.CurrentVal += 5;
    }

	public float returnHealth()
	{
		return Health.CurrentVal;
	}

	public void buyHealth()
	{
		for (int i = 0; i < 6; i++)
		{
			increaseHealth();
		}
	}

	public void updateMagic(int index)
	{
		availableMagics[index] = 1;
	}
	public int returnMagic(int index)
	{
		return availableMagics[index];
	}
}
