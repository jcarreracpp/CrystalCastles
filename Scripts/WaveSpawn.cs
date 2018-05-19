using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour {
    public GameObject enemy;
    public GameObject elfMage;
    public GameObject elfSage;
    public GameObject elfBow;
    public GameObject orcMelee;
    public GameObject orcThrowing;
    public GameObject orcBrute;
    public GameObject farmerHoe;
    public GameObject farmerPitchfork;
    public GameObject farmerScythe;
    public GameObject knightSheildSword;
    public GameObject knightLance;
    public GameObject knightCrossbow;

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
        spawnPoints.Add(GameObject.Find("SpawnPoint4").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint5").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint6").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint7").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint8").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint9").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint10").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint11").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint12").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint13").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint14").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint15").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint16").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint17").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint18").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint19").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint20").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint21").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint22").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint23").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint24").transform);
        switch (waveType)
        {
            case 1:
                enemies.Add(farmerHoe);
                enemies.Add(farmerPitchfork);
                enemies.Add(farmerScythe);
                break;
            case 2:
                enemies.Add(knightSheildSword);
                enemies.Add(knightLance);
                enemies.Add(knightCrossbow);
                break;
            case 3:
                enemies.Add(elfMage);
                enemies.Add(elfSage);
                enemies.Add(elfBow);
                break;
            case 4:
                enemies.Add(orcMelee);
                enemies.Add(orcThrowing);
                enemies.Add(orcBrute);
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