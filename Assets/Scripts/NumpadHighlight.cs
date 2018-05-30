using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumpadHighlight : MonoBehaviour {
    public float duration;
    public RawImage n1;
    public RawImage n2;
    public RawImage n3;
    public RawImage n4;
    public RawImage n5;
    public RawImage n6;
    public RawImage n7;
    public RawImage n8;
    public RawImage n9;
    Color temp;

    // Use this for initialization
    void Start () {
        temp = n1.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            StartCoroutine(BlinkPart(n7));
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            StartCoroutine(BlinkPart(n8));
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            StartCoroutine(BlinkPart(n9));
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            StartCoroutine(BlinkPart(n4));
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            StartCoroutine(BlinkPart(n5));
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            StartCoroutine(BlinkPart(n6));
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            StartCoroutine(BlinkPart(n1));
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            StartCoroutine(BlinkPart(n2));
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            StartCoroutine(BlinkPart(n3));
        }

    }

    IEnumerator BlinkPart(RawImage partBlink)
    {
        partBlink.color = Color.red;
        yield return new WaitForSeconds(duration);
        partBlink.color = temp;
        yield return null;
    }
}
