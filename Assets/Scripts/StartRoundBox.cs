using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRoundBox : MonoBehaviour {


	public Sprite farmerPortrait;
	public Sprite knightPortrait;
	public Sprite elfPortrait;
	public Sprite orcPortrait;
	public Sprite dragonPortrait;

	public GameObject portraitWindow;
	public GameObject characterText;

	// Use this for initialization
	void Start () {
		portraitWindow.GetComponent<Image> ().sprite = farmerPortrait;
		setText ("...");
	}

	public void setToFarmer(){
		portraitWindow.GetComponent<Image> ().sprite = farmerPortrait;
	}

	public void setToKnight(){
		portraitWindow.GetComponent<Image> ().sprite = knightPortrait;
	}

	public void setToElf(){
		portraitWindow.GetComponent<Image> ().sprite = elfPortrait;
	}

	public void setToOrc(){
		portraitWindow.GetComponent<Image> ().sprite = orcPortrait;
	}

	public void setToDragon(){
		portraitWindow.GetComponent<Image> ().sprite = dragonPortrait;
	}

	public void setText(string newText){
		characterText.GetComponent<Text> ().text = "\""+ newText + "\"";
	}
}
