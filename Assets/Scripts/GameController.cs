using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public string user = "";
    int empty;
	public Vector3 mousePosition;
    public Transform target;
    public Vector3 objectPosition;
    public float angle;
	public GameObject fireballPrefab, firewallPrefab;
	GameObject fireball, firewall;
	public Transform wizardPos;
    public AudioSource audioOut;
    AudioClip fireballSFX;

    // Use this for initialization
    void Start () {
        fireballSFX = Resources.Load("AudioFiles/robinhood-fireball-woosh") as AudioClip;
    }

	// Update is called once per frame
	void Update()
	{
		mousePosition = Input.mousePosition;
        objectPosition = Camera.main.WorldToScreenPoint(target.position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        angle = -(Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg) + 90;
        target.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
		user += Input.inputString;

		if (user.Contains("78965"))
		{
			Debug.Log("Fireball");
			fireball = Instantiate(fireballPrefab, wizardPos.position, wizardPos.rotation) as GameObject;
			fireball.GetComponent<Rigidbody>().velocity = fireball.transform.forward * 150f;
			Destroy(fireball, 2.0f);
            		playSound(fireballSFX);
            //VelocityChange or Impulse???
			user = "";
		}
		if (user.Contains("236589")) {
			Debug.Log("Knockback Wave");
            user = "";
        }
		if (user.Contains("4789614563"))
        {
			Debug.Log("Mud Wall");
            user = "";
        }
		if (user.Contains("1458936587159"))
        {
			Debug.Log("Chain Lightning");
            user = "";
        }
		if (user.Contains("759153751953"))
        {
			Debug.Log("Air Bomb");
            user = "";
        }
		//1258723698
		if (user.Contains("123"))
        {
            Debug.Log("Firewall");
			firewall = Instantiate(firewallPrefab, wizardPos.position, wizardPos.rotation) as GameObject;
            //firewall.GetComponent<Rigidbody>().velocity = firewall.transform.forward * 150f;
            user = "";
        }
		if (user.Contains("15986159863578435784"))
        {
            Debug.Log("Ice Lance");
            user = "";
        }
		if (user.Contains("7894561238741289632"))
        {
			Debug.Log("Geoslow");
            user = "";
        }

	}

    void playSound(AudioClip ac) {
        audioOut.mute = false;
        audioOut.Stop();
        audioOut.PlayOneShot(ac);
    }
}
