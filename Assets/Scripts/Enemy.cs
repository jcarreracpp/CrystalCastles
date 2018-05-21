using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private GameObject gameManager;
    private GameManager gm;
    public double hp;
    public enum faction {farmer,knight,elf,orc,dragon};
    public enum element { fire,water,wind,earth,none}
    public faction myFaction;
    public element weakness;
    public element advantage;
    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            death();
        }

        //debugging
        if (Input.GetKeyDown(KeyCode.D))
        {
            takeDamage(2, 10);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            death();
        }


    }

    
    public void takeDamage(float damage, int atkType)
    {
        if (atkType == (int)weakness)
        {
            hp -= (damage * 2);
        }
        else if (atkType == (int)advantage)
        {
            hp-= (float)(damage/2);
        }
        else
        {
            hp -= damage;
        }
    }
    public double HP
    {
        get { return hp; }
        set { hp = value; }
    }
   
    private void death()
    {
        gm.decrementEnemiesRemaining();
        Destroy(this.gameObject);

    }
}
