using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    private GameObject gameManager;
    private GameManager gm;
    private GameObject shopControl;
    private ShopControlScript sc;
    public double MAXHP;
    private double currentHP;
    public enum faction {farmer,knight,elf,orc,dragon};
    public enum element { fire,water,wind,earth,none}
    public faction myFaction;
    public element weakness;
    public element advantage;
    

    public GameObject healthBar;

    private int gold;
    // Use this for initialization
    void Start () {
        
        currentHP = MAXHP;
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
        shopControl = GameObject.Find("ShopControl");
        sc = shopControl.GetComponent<ShopControlScript>();
        gold = (int)MAXHP;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (currentHP<= 0)
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
            damage*=2;
        }
        else if (atkType == (int)advantage)
        {
            damage/=2;
        }
       

        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
        healthBar.transform.localScale = new Vector3((float)currentHP/(float)MAXHP,1,1);
        
    }
    public void heal(double helath)
    {
        currentHP += helath;
        if (currentHP > MAXHP)
        {
            currentHP = MAXHP;
        }
        healthBar.transform.localScale = new Vector3((float)currentHP / (float)MAXHP, 1, 1);
    }
    
   
    private void death()
    {
        gm.decrementEnemiesRemaining();
        sc.addMoney(gold);
        
        
        Destroy(this.gameObject);
        

    }
    
}
