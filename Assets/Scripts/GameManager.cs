using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private int money;
	private int wave;
	private int enemyCount;


	[SerializeField]
	private Text moneyText;
	[SerializeField]
	private Text waveText;
	[SerializeField]
	private Text enemiesRemainingText;
	[SerializeField]
	private Text gameOverText;

	[SerializeField]
	private GameObject playerObject;
	private Player playerScript;



	// Use this for initialization
	void Start () {
		playerScript = playerObject.GetComponent<Player>();
		Money = 0;
		Wave = 1;
		EnemyCount = 5;
	}

	// Update is called once per frame
	void Update () {
		if(playerScript.Health.CurrentVal <= 0)
		{
			gameOverText.gameObject.SetActive (true);
		}
	}


	public int Money
	{
		get { return money; }
		set { 
			this.money = value;
			this.moneyText.text = value.ToString(); 
		}
	}

	public int Wave
	{
		get { return wave; }
		set { 
			this.wave = value;
			this.waveText.text = "Wave: " + value.ToString(); 
		}
	}

	public int EnemyCount
	{
		get{ return enemyCount; }
		set
		{
			this.enemyCount = value;
			this.enemiesRemainingText.text = "Enemies Remaining: " + value.ToString ();
		}
	}

    public void gotoShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
