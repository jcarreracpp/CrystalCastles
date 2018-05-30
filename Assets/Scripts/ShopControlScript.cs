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

    public Text fireballBtnTxt;
    public Text firewallBtnTxt;
    public Text waveBtnTxt;
    public Text lanceBtnTxt;
    public Text mudWallBtnTxt;
    public Text geoBtnTxt;
    public Text airBtnTxt;
    public Text chainBtnTxt;
    public Text healthBtnTxt;


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
            healthBuyBtn.GetComponent<Button>().interactable = true;

        // Check money && inventory for fireball
        if (moneyAmount < 75)
        {
            fireballBtnTxt.GetComponentInChildren<Text>().text = "N/A";
            fireballBuyBtn.GetComponent<Button>().interactable = false;
        }

        // Check money && inventory for firewall
        if (moneyAmount < 250)
        {
            firewallBuyBtn.GetComponent<Button>().interactable = false;
            firewallBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }

        // Check money && inventory for knockback wave
        if (moneyAmount < 100)
        {
            waveBuyBtn.GetComponent<Button>().interactable = false; 
            waveBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }

        // Check money && inventory for lance
        if (moneyAmount < 275)
        {
            lanceBuyBtn.GetComponent<Button>().interactable = false;
            lanceBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }

        // Check money && inventory for mudWall
        if (moneyAmount < 200)
        {
            wallBuyBtn.GetComponent<Button>().interactable = false;
            mudWallBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }

        // Check money && inventory for geo
        if (moneyAmount < 300)
        {
            geoBuyBtn.GetComponent<Button>().interactable = false;
            geoBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }

        // Check money && inventory for air bomb
        if (moneyAmount < 125)
        {
            airBuyBtn.GetComponent<Button>().interactable = false;
            airBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }

        // Check money && inventory for chain lightning
        if (moneyAmount < 275)
        {
            chainBuyBtn.GetComponent<Button>().interactable = false;
            chainBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }

        //check health
        if((int)gManager.returnHealth() == 30)
        {
            healthBuyBtn.GetComponent<Button>().interactable = false;
        }

        //check health money
        if (moneyAmount < 100)
        {
            healthBuyBtn.gameObject.SetActive(false);
            healthBtnTxt.GetComponentInChildren<Text>().text = "N/A";
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
        // set health full
        gManager.buyHealth();
        healthPriceTxt.text = "SOLD";
        healthBuyBtn.gameObject.SetActive(false);
    }
    public void addMoney(int money)
    {
        moneyAmount += money;
    }

}
