using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	private float fillAmount;

	[SerializeField]
	private float lerpSpeed;	//for bar health movement. Not chunking.

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText;

	public float MaxValue { get; set; }

	public float Value
	{
		set
		{ 
			//splits hp:30/30 into [hp, 30/30]
			string[] tmp = valueText.text.Split(':');
			valueText.text = tmp [0] + ": " + value + "/" + MaxValue;
			fillAmount = Map (value, 0, MaxValue, 0, 1); 
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar ();
	}

	private void HandleBar()
	{
		if(fillAmount != content.fillAmount)
		{
			content.fillAmount = Mathf.Lerp (content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}
		
	//inMin = min health ex. 0; inMax is max health ex. 30; outMin = min value between 1; outMax = max value of 0 to 1;
	//This is for the sake of scaling the bar. 0-30. 0-100. 0-230. All work on bar.
	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
