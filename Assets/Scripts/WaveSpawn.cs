using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour {
    public GameObject enemy;
    public GameObject elf;
    public GameObject orc;
    public GameObject farmer;
    public GameObject knight;
    public List<GameObject> enemies;
    public List <Transform> spawnPoints;
    bool started = false;
    int i = 0;
    int waveType;
    


    // Use this for initialization
    void Start () {
        waveType = Random.Range(0, 4);
        spawnPoints.Add(GameObject.Find("SpawnPoint1").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint2").transform);
        spawnPoints.Add(GameObject.Find("SpawnPoint3").transform);

        enemies.Add(enemy);
        enemies.Add(farmer);
        enemies.Add(knight);
        enemies.Add(elf);
        enemies.Add(orc);
       
        


    }

    // Update is called once per frame
    void Update() {
        int chance = Random.Range(0,1000);
        if (started && i < 20 && chance > 982)
        {
            int index = Random.Range(0, spawnPoints.ToArray().Length);
            Instantiate(enemies[waveType], spawnPoints[index].position, spawnPoints[index].rotation);
            i++;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            started = true;
        }
        




    }
}
