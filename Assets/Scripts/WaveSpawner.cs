using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	//Enemies by factions
	public Transform[] farmers;
	public Transform[] knights;
	public Transform[] elves;
	public Transform[] orcs;
	public Transform[] dragons;
	//Spawn Points
	public Transform[] spawnPoints;

	public SpawnState state = SpawnState.SPAWNING;


	void Start ()
	{
		if(spawnPoints.Length == 0)
		{
			Debug.LogError ("No spawn points reference.");
		}
	}
		
	void Update()
	{

		if (state == SpawnState.WAITING) {
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
				StartCoroutine(SpawnWave(nextWave));
			} 
		} 
			
	}

	void WaveCompleted ()
	{
		Debug.Log ("Wave Copmleted!");
		//pause = true;
		Debug.Log ("Spawn Paused. Time to open Shop.");
		//A method that interacts and opens the shop
		//...
		nextWave++;
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
			if (nextWave > 8) {
				/*
				farmerChance = .1;
				knightChance = .2;
				elfChance = .2;
				orcChance = .3;
				dragonChance = .2;
				*/
			} else if (nextWave > 6) {
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
			} else if (nextWave > 4) {
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
			} else if (nextWave > 2) {
				/*
				farmerChance = .7;
				knightChance = .3;
				elfChance = 0;
				orcChance = 0;
				dragonChance = 0;
				*/
				if (temp > .7) {
					SpawnEnemy (knights[Random.Range(0,3)]);
				} else {
					SpawnEnemy (farmers[Random.Range(0,3)]);
				}
			} else {
				/*
				farmerChance = 1;
				knightChance = 0;
				elfChance = 0;
				orcChance = 0;
				dragonChance = 0;
				*/
				SpawnEnemy (farmers[Random.Range(0,3)]);
			}

			yield return new WaitForSeconds ( 1f/rate );
		}

		//Every 2 rounds, we spawn 3 more.
		if(nextWave%2 == 0 && nextWave != 0){
			Debug.Log ("Spawning 3 more units");
			spawnCount += 3;
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

}
