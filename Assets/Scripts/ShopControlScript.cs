using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {

    public GameManager gManager;

    int moneyAmount;
    int [] soldMagics;
    /*
    int isFireballSold;
    int isFirewallSold;
    int isWaveSold;
    int isLanceSold;
    int isMudwallSold;
    int isGeoSold;
    int isAirSold;
    int isChainSold;
    int isHealthFull;
    */

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
        this.money_Text.text = "Money: " + moneyAmount.ToString() + " G";
        soldMagics = new int[8];
        
	}
	
	// Update is called once per frame
	void Update () {
        /*
        isFireballSold = 0; // current fireball status;
        isFirewallSold = 0; // current firewall status;

        // check fireball is purchaseable
        
         * 
         * if (moneyAmount >= 75 && isFireballSold == 0)
            fireballBuyBtn.interactable = true;
        else
            fireballBuyBtn.interactable = false;

        //check firewall is purchaseable
        if (moneyAmount >= 250 && isFirewallSold == 0)
            firewallBuyBtn.interactable = true;
        else
            firewallBuyBtn.interactable = false;
         */


         //Receive current magic sales status.
         for(int i = 0; i < 8; i++)
        {
            soldMagics[i] = gManager.returnMagic(i);
        }

    }

    public void exitShop()
    {
        // set changed money value.
        gManager.Money = moneyAmount;
        SceneManager.LoadScene("default");
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

}
