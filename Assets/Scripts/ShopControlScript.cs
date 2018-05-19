using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {
    int moneyAmount;
    int isFireballSold;
    int isFirewallSold;

    public Text money_Text;
    public Text fireballPriceTxt;
    public Text firewallPriceTxt;

    public Button fireballBuyBtn;
    public Button firewallBuyBtn;


	// Use this for initialization
	void Start () {
        moneyAmount = 0; // current money amount
	}
	
	// Update is called once per frame
	void Update () {
        money_Text.text = "Money: " + moneyAmount.ToString() + "$";
        isFireballSold = 0; // current fireball status;
        isFirewallSold = 0; // current firewall status;

        // check fireball is purchaseable
        if (moneyAmount >= 75 && isFireballSold == 0)
            fireballBuyBtn.interactable = true;
        else
            fireballBuyBtn.interactable = false;

        //check firewall is purchaseable
        if (moneyAmount >= 250 && isFirewallSold == 0)
            firewallBuyBtn.interactable = true;
        else
            firewallBuyBtn.interactable = false;
    }

    public void exitShop()
    {
        // set changed money value.
        SceneManager.LoadScene("default");
    }

    public void buyFireball()
    {
        moneyAmount -= 75;
        // set fireball buy status to 1
        fireballPriceTxt.text = "SOLD";
        fireballBuyBtn.gameObject.SetActive(false);
    }

    public void buyFirewall()
    {
        moneyAmount -= 250;
        // set firewall buy status to 1
        firewallPriceTxt.text = "SOLD";
        firewallBuyBtn.gameObject.SetActive(false);
    }

}
