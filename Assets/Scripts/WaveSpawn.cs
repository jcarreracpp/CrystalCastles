using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour {
    public GameObject enemy;
    public GameObject elf;
    public GameObject orc;
    public GameObject farmerHoe;
    public GameObject farmerPitchfork;
    public GameObject farmerScythe;
    public GameObject knightSheildSword;
    
    public List <Transform> spawnPoints;
    bool started = false;
    int enemyCount = 0;
    public int maxEnemyCount;
    int waveType;
    public List<GameObject> enemies;
    



    // Use this for initialization
    void Start () {
        waveType = Random.Range(0, 5);
        spawnPoints.Add(GameObject.Find("SpawnPoint1").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint2").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint3").transform);

        

        switch (waveType)
        {
            case 1:
                enemies.Add(farmerHoe);
                enemies.Add(farmerPitchfork);
                enemies.Add(farmerScythe);
                break;
            case 2:
                enemies.Add(knightSheildSword);
                break;
            case 3:
                enemies.Add(elf);
                break;
            case 4:
                enemies.Add(orc);
                break;
            default:
                enemies.Add(enemy);
                break;

        }


    }

    // Update is called once per frame
    void Update()
    {
        int chance = Random.Range(0, 1000);
        if (started && enemyCount < maxEnemyCount && chance > 982)
        {
            int enemyIndex = Random.Range(0, enemies.ToArray().Length);
            int spawnPointIndex = Random.Range(0, spawnPoints.ToArray().Length);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemyCount++;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            started = true;
        }
            
        
    }
}