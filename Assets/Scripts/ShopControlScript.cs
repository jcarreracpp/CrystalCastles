using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {

    public GameManager gManager;
    
    int moneyAmount;
    int currentHealth;
    int [] soldMagics;
    

    public Text money_Text;
    public Text fireballPriceTxt;
    public Text firewallPriceTxt;
    public Text wavePriceTxt;
    public Text lancePriceTxt;
    public Text mudWallPriceTxt;
    public Text geoPriceTxt;
    public Text airPriceTxt;
    public Text chainPriceTxt;
    public Text healthPriceTxt;

    public Button fireballBuyBtn;
    public Button firewallBuyBtn;
    public Button waveBuyBtn;
    public Button lanceBuyBtn;
    public Button wallBuyBtn;
    public Button geoBuyBtn;
    public Button airBuyBtn;
    public Button chainBuyBtn;
    public Button healthBuyBtn;


	// Use this for initialization
	void Start () {
        moneyAmount = gManager.Money; // current money amount
        money_Text.text = "Money: " + moneyAmount.ToString() + " G";
        currentHealth = (int)gManager.returnHealth();
        soldMagics = new int[8];
        
        //Receive current magic sales status
        for (int i = 0; i < 8; i++)
        {
            soldMagics[i] = gManager.returnMagic(i);
        }

    }
	
	// Update is called once per frame
	void Update () {
        chekcMagicStatus();
        gManager.Money = moneyAmount;


        
    }

    public void chekcMagicStatus()
    {
        if((int)gManager.returnHealth() < 30)
            healthBuyBtn.gameObject.SetActive(true);

        // Check money && inventory for fireball
        if (moneyAmount < 75)
        {
            fireballPriceTxt.text = "N/A";
            fireballBuyBtn.gameObject.SetActive(false);
        }

        // Check money && inventory for firewall
        if (moneyAmount < 250)
        {
            firewallPriceTxt.text = "N/A";
            firewallBuyBtn.gameObject.SetActive(false);
        }

        // Check money && inventory for knockback wave
        if (moneyAmount < 100)
        {
            wavePriceTxt.text = "N/A";
            waveBuyBtn.gameObject.SetActive(false);
        }

        // Check money && inventory for lance
        if (moneyAmount < 275)
        {
            lancePriceTxt.text = "N/A";
            lanceBuyBtn.gameObject.SetActive(false);
        }

        // Check money && inventory for mudWall
        if (moneyAmount < 200)
        {
            mudWallPriceTxt.text = "N/A";
            wallBuyBtn.gameObject.SetActive(false);
        }

        // Check money && inventory for geo
        if (moneyAmount < 300)
        {
            geoPriceTxt.text = "N/A";
            geoBuyBtn.gameObject.SetActive(false);
        }

        // Check money && inventory for air bomb
        if (moneyAmount < 125)
        {
            airPriceTxt.text = "N/A";
            airBuyBtn.gameObject.SetActive(false);
        }

        // Check money && inventory for chain lightning
        if (moneyAmount < 275)
        {
            chainPriceTxt.text = "N/A";
            chainBuyBtn.gameObject.SetActive(false);
        }

        //check health
        if((int)gManager.returnHealth() == 30)
        {
            healthPriceTxt.text = "FULL";
            healthBuyBtn.gameObject.SetActive(false);
        }

        //check health money
        if (moneyAmount < 100)
        {
            healthPriceTxt.text = "N/A";
            healthBuyBtn.gameObject.SetActive(false);
        }
    }
    

    public void buyFireball()
    {
        moneyAmount -= 75;
        gManager.updateMagic(0);
        // set fireball buy status to 1
        fireballPriceTxt.text = "SOLD";
        fireballBuyBtn.gameObject.SetActive(false);
    }

    public void buyFirewall()
    {
        moneyAmount -= 250;
        gManager.updateMagic(1);
        // set firewall buy status to 1
        firewallPriceTxt.text = "SOLD";
        firewallBuyBtn.gameObject.SetActive(false);
    }

    public void buyWave()
    {
        moneyAmount -= 200;
        gManager.updateMagic(2);
        // set wave buy status to 1
        wavePriceTxt.text = "SOLD";
        waveBuyBtn.gameObject.SetActive(false);
    }

    public void buyLance()
    {
        moneyAmount -= 275;
        gManager.updateMagic(3);
        // set wave buy status to 1
        lancePriceTxt.text = "SOLD";
        lanceBuyBtn.gameObject.SetActive(false);
    }

    public void buyWall()
    {
        moneyAmount -= 200;
        gManager.updateMagic(4);
        // set wave buy status to 1
        mudWallPriceTxt.text = "SOLD";
        wallBuyBtn.gameObject.SetActive(false);
    }

    public void buyGeo()
    {
        moneyAmount -= 300;
        gManager.updateMagic(5);
        // set wave buy status to 1
        geoPriceTxt.text = "SOLD";
        geoBuyBtn.gameObject.SetActive(false);
    }

    public void buyAir()
    {
        moneyAmount -= 125;
        gManager.updateMagic(6);
        // set wave buy status to 1
        airPriceTxt.text = "SOLD";
        airBuyBtn.gameObject.SetActive(false);
    }

    public void buyChain()
    {
        moneyAmount -= 200;
        gManager.updateMagic(7);
        // set wave buy status to 1
        chainPriceTxt.text = "SOLD";
        chainBuyBtn.gameObject.SetActive(false);
    }

    public void buyHealth()
    {
        moneyAmount -= 100; // not sure how much it will be
        // set wave buy status to 1
        healthPriceTxt.text = "SOLD";
        healthBuyBtn.gameObject.SetActive(false);
    }
    public void addMoney(int money)
    {
        moneyAmount += money;
    }

}
