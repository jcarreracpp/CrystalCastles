using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRoundBox : MonoBehaviour {


	public Sprite tutorialPortrait;
	public Sprite farmerPortrait;
	public Sprite knightPortrait;
	public Sprite elfPortrait;
	public Sprite orcPortrait;
	public Sprite dragonPortrait;

	public GameObject portraitWindow;
	public GameObject characterText;

	// Use this for initialization
	void Start () {
		portraitWindow.GetComponent<Image> ().sprite = tutorialPortrait;
		setText ("Made By: Bryce Metcalf, Jacob Kim, Jorge Carrera, David Escobedo, and William Kenji Kiplinger\nMusic: World of Warcraft Battle Music\nControls:\n1. Aim with mouse 2. Enter numpad combo for spells\nNOTE* Only fireball spell works in demo");
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
