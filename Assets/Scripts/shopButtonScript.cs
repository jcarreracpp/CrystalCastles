using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopButtonScript : MonoBehaviour {

    public GameObject Panel;
    int counter = 1;
    public Text exitText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showhidPanel()
    {
        counter++;
        if (counter % 2 == 1)
        {
            exitText.text = "SOLD";
            Panel.gameObject.SetActive(false);
        }
        else
        {
            exitText.text = "SHOP";
            Panel.gameObject.SetActive(true);
        }
    }
}
