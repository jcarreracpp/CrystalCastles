using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
    public Vector3 mousePosition;
    public Transform target;
    public Vector3 objectPosition;
    public float angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = Input.mousePosition;
        objectPosition = Camera.main.WorldToScreenPoint(target.position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        angle = -(Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg)+90;
        target.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
	}
}
