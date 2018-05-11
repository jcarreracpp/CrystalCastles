using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttackWithinRange : MonoBehaviour {
    public float range;
    Transform player;
    public float frequency;
    float timer;
    public GameObject projectile;
    public float speed;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (Vector3.Distance(this.transform.position, player.transform.position) <= range && timer >= frequency)
        {
            StartCoroutine(shoot());
        }
        else
        {
        }
        if (timer >= frequency)
            timer = 0;
    }

    IEnumerator shoot() {
        GameObject firedProjectile = Instantiate(projectile, this.transform.position, Quaternion.identity) as GameObject;
        firedProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * speed);

        yield return null;
    }
}
