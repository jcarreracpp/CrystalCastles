using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithinRange : MonoBehaviour {

    public float range;
    Transform player;
    public float frequency;
    public int damage;
    private float timer;
    private Player playerHealth;
    


    // Use this for initialization
    void Start()
    {
        timer = 0;
        player = GameObject.Find("Player").transform;
        playerHealth = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(this.transform.position, player.transform.position) <= range && timer >= frequency)
        {
            playerHealth.modifyHealth(-damage);
        }

        if (timer >= frequency)
        {
            timer = 0;
        }
    }

    
}
