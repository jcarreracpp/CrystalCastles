using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour {
    Player player;
    GameObject playerBody;
    public int damage;

	// Use this for initialization
	void Start () {
        playerBody = GameObject.Find("Player");
        player = playerBody.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player") {
            player.modifyHealth(-damage);
            Destroy(this.gameObject);
        }
    }
}
