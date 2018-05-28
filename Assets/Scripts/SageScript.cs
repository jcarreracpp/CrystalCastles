using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SageScript : MonoBehaviour {
    public double regen;
    public float frequency;
    private float timer;
    private GameObject[] enemies;
    private Enemy health;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= frequency)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {

                health = enemy.GetComponent<Enemy>();
                health.heal(regen);

            }
            
        }
        if (timer >= frequency)
        {
            timer = 0;
        }

    }
}
