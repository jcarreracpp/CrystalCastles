using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{

    public int cost;
    public int speed;
    public int size;
    public int mana;
    public int rank;
    public int upgradeCost;
	public int damage;
	public string combination;

    public Spells()
    {

    }

    public int Cost
    {
        get { return cost; }
        set { this.cost = value; }
    }

    public int Size
    {
        get { return size; }
        set { this.size = value; }
    }

    public int Mana
    {
        //GameManager manager = new GameManager();
        get { return mana; }
        set { this.mana = value; }
    }

    public int Rank
    {
        get { return rank; }
        set { this.rank = value; }
    }

    public int UpgradeCost
    {
        get { return upgradeCost; }
        set { this.upgradeCost = value; }
    }

	public int damage {
		get { return damage; }
		set { this.damage = value; }
	}

	public string combination {
		get { return combination; }
		set { this.combination = value; }
	}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}