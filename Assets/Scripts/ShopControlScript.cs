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

    public Player player;
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
        moneyAmount = player.Money; // current money amount
        //money_Text.text = moneyAmount.ToString();
        currentHealth = (int)player.returnHealth();
        soldMagics = new int[8];
        
        //Receive current magic sales status
        for (int i = 0; i < 8; i++)
        {
            soldMagics[i] = player.returnMagic(i);
        }

    }
	
	// Update is called once per frame
	void Update () {
        chekcMagicStatus();
    }

    public void chekcMagicStatus()
    {

        // Check money && inventory for fireball
        if (moneyAmount < 75)
        {
            fireballBtnTxt.GetComponentInChildren<Text>().text = "N/A";
            fireballBuyBtn.GetComponent<Button>().interactable = false;
        }
        else
        { 
            fireballBtnTxt.GetComponentInChildren<Text>().text = "BUY";
            fireballBuyBtn.GetComponent<Button>().interactable = true;
        }

        // Check money && inventory for firewall
        if (moneyAmount < 250)
        {
            firewallBuyBtn.GetComponent<Button>().interactable = false;
            firewallBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }
        else
        {
            firewallBuyBtn.GetComponent<Button>().interactable = true;
            firewallBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }

        // Check money && inventory for knockback wave
        if (moneyAmount < 100)
        {
            waveBuyBtn.GetComponent<Button>().interactable = false; 
            waveBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }
        else
        {
            waveBuyBtn.GetComponent<Button>().interactable = true;
            waveBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }

        // Check money && inventory for lance
        if (moneyAmount < 275)
        {
            lanceBuyBtn.GetComponent<Button>().interactable = false;
            lanceBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }
        else
        {
            lanceBuyBtn.GetComponent<Button>().interactable = true;
            lanceBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }

        // Check money && inventory for mudWall
        if (moneyAmount < 200)
        {
            wallBuyBtn.GetComponent<Button>().interactable = false;
            mudWallBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }
        else
        { 
            wallBuyBtn.GetComponent<Button>().interactable = true;
            mudWallBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }

        // Check money && inventory for geo
        if (moneyAmount < 300)
        {
            geoBuyBtn.GetComponent<Button>().interactable = false;
            geoBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }
        else
        {
            geoBuyBtn.GetComponent<Button>().interactable = true;
            geoBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }

        // Check money && inventory for air bomb
        if (moneyAmount < 125)
        {
            airBuyBtn.GetComponent<Button>().interactable = false;
            airBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }
        else
        {
            airBuyBtn.GetComponent<Button>().interactable = true;
            airBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }

        // Check money && inventory for chain lightning
        if (moneyAmount < 275)
        {
            chainBuyBtn.GetComponent<Button>().interactable = false;
            chainBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }
        else
        {
            chainBuyBtn.GetComponent<Button>().interactable = true;
            chainBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }

       
        //check health money
        if (moneyAmount < 100)
        {
            healthBuyBtn.GetComponent<Button>().interactable = false;
            healthBtnTxt.GetComponentInChildren<Text>().text = "N/A";
        }
        else
        {
            healthBuyBtn.GetComponent<Button>().interactable = true;
            healthBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }

        //check health
        if ((int)player.returnHealth() == 30)
        {
            healthBuyBtn.GetComponent<Button>().interactable = false;
            healthBtnTxt.GetComponentInChildren<Text>().text = "FULL";
        }
        else
        {
            healthBuyBtn.GetComponent<Button>().interactable = true;
            healthBtnTxt.GetComponentInChildren<Text>().text = "BUY";
        }
    }


    public void buyFireball()
    {
        moneyAmount -= 75;
        player.updateMagic(0);
        // set fireball buy status to 1
        fireballPriceTxt.text = "SOLD";
        fireballBuyBtn.gameObject.SetActive(false);
        this.money_Text.text = moneyAmount.ToString();
    }

    public void buyFirewall()
    {
        moneyAmount -= 250;
        player.updateMagic(1);
        // set firewall buy status to 1
        firewallPriceTxt.text = "SOLD";
        firewallBuyBtn.gameObject.SetActive(false);
        this.money_Text.text = moneyAmount.ToString();
    }

    public void buyWave()
    {
        moneyAmount -= 200;
        player.updateMagic(2);
        // set wave buy status to 1
        wavePriceTxt.text = "SOLD";
        waveBuyBtn.gameObject.SetActive(false);
        this.money_Text.text = moneyAmount.ToString();
    }

    public void buyLance()
    {
        moneyAmount -= 275;
        player.updateMagic(3);
        // set wave buy status to 1
        lancePriceTxt.text = "SOLD";
        lanceBuyBtn.gameObject.SetActive(false);
        this.money_Text.text = moneyAmount.ToString();
    }

    public void buyWall()
    {
        moneyAmount -= 200;
        player.updateMagic(4);
        // set wave buy status to 1
        mudWallPriceTxt.text = "SOLD";
        wallBuyBtn.gameObject.SetActive(false);
        this.money_Text.text = moneyAmount.ToString();
    }

    public void buyGeo()
    {
        moneyAmount -= 300;
        player.updateMagic(5);
        // set wave buy status to 1
        geoPriceTxt.text = "SOLD";
        geoBuyBtn.gameObject.SetActive(false);
        this.money_Text.text = moneyAmount.ToString();
    }

    public void buyAir()
    {
        moneyAmount -= 125;
        player.updateMagic(6);
        // set wave buy status to 1
        airPriceTxt.text = "SOLD";
        airBuyBtn.gameObject.SetActive(false);
        this.money_Text.text = moneyAmount.ToString();
    }

    public void buyChain()
    {
        moneyAmount -= 200;
        player.updateMagic(7);
        // set wave buy status to 1
        chainPriceTxt.text = "SOLD";
        chainBuyBtn.gameObject.SetActive(false);
        this.money_Text.text = moneyAmount.ToString();
    }

    public void buyHealth()
    {
        moneyAmount -= 100; // not sure how much it will be
        // set health full
        player.buyHealth();
        healthBuyBtn.GetComponent<Button>().interactable = false;
        this.money_Text.text = moneyAmount.ToString();
    }
    public void addMoney(int money)
    {
        moneyAmount += money;
        this.money_Text.text = moneyAmount.ToString();
    }

}
