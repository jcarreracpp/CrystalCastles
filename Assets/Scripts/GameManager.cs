using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private int money;
	private int wave;
	private int enemyCount;

    private int[] availableMagics;
    // indicator of bought magics


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

        availableMagics = new int[8];
        for(int i = 0; i < 8; i++)
        {
            availableMagics[i] = 0;
        }
        // 0 = not available, 1 = usable
        //[0] = fireball, [1] = firewall, [2] = knockbackwave, [3] = icelance, [4] = mudWall, [5] = geoslow, [6] = airbomb, [7] = chainLightning
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

	//This will be called by WaveSpawner at the start of rounds
	public void setEnemiesRemainingMax(int newMax){
		EnemyCount = newMax;
	}
		
	//This will be called by enemies when their hp reaches < 0
	public void decrementEnemiesRemaining(){
		EnemyCount--;
	}

    public void updateMagic(int index)
    {
        availableMagics[index] = 1;
    }

    public int returnMagic(int index)
    {
        return availableMagics[index];
    }

    public float returnHealth()
    {
        return playerScript.Health.CurrentVal;
    }

    public void buyHealth()
    {
        for(int i = 0; i < 6; i++)
        {
            playerScript.increaseHealth();
        }
    }

}
