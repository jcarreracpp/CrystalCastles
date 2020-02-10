using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState {SPAWNING, WAITING};

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	private int nextWave = 0;
	public float rate;
	private int spawnCount = 10;
	private float searchCountdown = 1f;
	//Shop needs to change this back to false to resume wave
	public bool pause = false;
    //bryce
    private bool waveStarted = false;

	//Enemies by factions
	public Transform[] farmers;
	public Transform[] knights;
	public Transform[] elves;
	public Transform[] orcs;
	public Transform[] dragons;
	//Spawn Points
	public Transform[] spawnPoints;

	public SpawnState state = SpawnState.SPAWNING;

	public GameObject waveText;

	//updates portrait and text
	public GameObject startRoundBox;
	private StartRoundBox startRoundBoxScript;

	public GameObject startRoundBoxOutline;
	public GameObject startRoundBoxCloseButton;

	//responsible for connecting with GameManager and calling a method
	public GameObject gameManager;
	private GameManager gameManagerScript;

	void Start ()
	{
		startRoundBoxOutline.gameObject.SetActive (true);
		startRoundBoxCloseButton.gameObject.SetActive (true);
		pause = true;
		gameManagerScript = gameManager.GetComponent<GameManager> ();
		startRoundBoxScript = startRoundBox.GetComponent<StartRoundBox> ();
		setEnemiesRemainingTextMax ();
		waveText.GetComponent<Text>().text = "Wave: " + (nextWave+1);
		if(spawnPoints.Length == 0)
		{
			Debug.LogError ("No spawn points reference.");
		}
	}
		
	void Update()
	{
        //bryce
		if (state == SpawnState.WAITING && pause == false && waveStarted == true) {
			//Check if enemies are still alive
			if (!EnemyIsAlive ()) {
				WaveCompleted ();
			} else {
				return;
			}
		}
			
		if(pause == false)
		{
			if (state != SpawnState.SPAWNING) 
			{
				// Start spawning wave
				setEnemiesRemainingTextMax ();
				StartCoroutine(SpawnWave(nextWave));
                //bryce
                waveStarted = true;
			} 
		} 
			
	}

	public void closeDialogue()	{
		startRoundBoxOutline.gameObject.SetActive (false);
		startRoundBoxCloseButton.gameObject.SetActive (false);
		pause = false;
	}

	void WaveCompleted ()
	{
		Debug.Log ("Wave Copmleted!");
		//pause = true;
		Debug.Log ("Spawn Paused. Time to open Shop.");
		//A method that interacts and opens the shop
		//...
		nextWave++;
		waveText.GetComponent<Text>().text = "Wave: " + (nextWave+1);
		startRoundBoxOutline.gameObject.SetActive (true);
		startRoundBoxCloseButton.gameObject.SetActive (true);
		pause = true;
        //bryce
        waveStarted = false;
	}

	//Checks every searchCountdown (set to 1, so every 1 second)
	bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;
		if(searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if(GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}
		
	//Logic behind spawns
	IEnumerator SpawnWave (int nextWave)
	{
		Debug.Log ("Spawning Wave: " + nextWave);
		state = SpawnState.SPAWNING;

		// Spawn
		for(int i = 0; i < spawnCount; i++)
		{
			float temp = Random.Range (0.0f, 1.0f);

			//Changing the percent chance of spawning type of enemy.
			if (nextWave >= 4) {
				/*
				farmerChance = .1;
				knightChance = .2;
				elfChance = .2;
				orcChance = .3;
				dragonChance = .2;
				*/
				startRoundBoxScript.setToDragon ();
				startRoundBoxScript.setText ("RAAAAAAAAAAAAAAAAAAAAAWWWWWWWWWWWWWWWWWWWWRRRRRRRRRRRRRRRRRR");
			} else if (nextWave >= 3) {
				/*
				farmerChance = .3;
				knightChance = .2;
				elfChance = .3;
				orcChance = .2;
				dragonChance = 0;
				*/
				if (1 > temp && temp >= .8) {
					SpawnEnemy (orcs[Random.Range(0,3)]);
				} else if (.8 > temp && temp >= .5) {
					SpawnEnemy (elves[Random.Range(0,3)]);
				} else if (.5 > temp && temp > .3) {
					SpawnEnemy (knights[Random.Range(0,3)]);
				} else {
					SpawnEnemy (farmers[Random.Range(0,3)]);
				}
				startRoundBoxScript.setToOrc ();
				startRoundBoxScript.setText ("We act like we look. Evilly!");
			} else if (nextWave >= 2) {
				/*
				farmerChance = .5;
				knightChance = .3;
				elfChance = .2;
				orcChance = 0;
				dragonChance = 0;
				*/

				if (temp > .8) {
					SpawnEnemy (elves[Random.Range(0,3)]);
				} else if (temp > .7) {
					SpawnEnemy (knights[Random.Range(0,3)]);
				} else {
					SpawnEnemy (farmers[Random.Range(0,3)]);
				}
				startRoundBoxScript.setToElf ();
				startRoundBoxScript.setText ("We are magical ELVES. We do magical things like magically killing people!");
			} else if (nextWave >= 1) {
				/*
				farmerChance = .7;
				knightChance = .3;
				elfChance = 0;
				orcChance = 0;
				dragonChance = 0;
				*/
				if (temp >=1) {
					SpawnEnemy (knights[Random.Range(0,3)]);
				} else {
					SpawnEnemy (farmers[Random.Range(0,3)]);
				}
				startRoundBoxScript.setToKnight ();
				startRoundBoxScript.setText ("For crimes against the kingdom, the king has ordered your death!");
			} else {
				/*
				farmerChance = 1;
				knightChance = 0;
				elfChance = 0;
				orcChance = 0;
				dragonChance = 0;
				*/
				SpawnEnemy (farmers[Random.Range(0,3)]);
				startRoundBoxScript.setToFarmer ();
				startRoundBoxScript.setText ("Get off my property!");
			}

			yield return new WaitForSeconds ( 1f/rate );
		}

		//Every 2 rounds, we spawn 3 more.
		if(nextWave%2 == 0 && nextWave != 0){
			Debug.Log ("Spawning 3 more units");
			spawnCount += 2;
		}
		state = SpawnState.WAITING;

		yield break;
	}
		
	void SpawnEnemy (Transform _enemy)
	{
		//Spawn enemy
		Debug.Log("Spawning Enemy");

		Transform _sp = spawnPoints [Random.Range(0,spawnPoints.Length)];
		Instantiate(_enemy, _sp.position, _sp.rotation);
	}

	public void setEnemiesRemainingTextMax(){
		gameManagerScript.setEnemiesRemainingMax (spawnCount);
	}

}
