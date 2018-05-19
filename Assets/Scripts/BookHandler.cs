using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHandler : MonoBehaviour {
    public SkinnedMeshRenderer smr;
    public float speed;
    public bool isRunning = false;


    public void flipRight() {
        if (!isRunning) {
            isRunning = true;
            StartCoroutine(right());
        }
    }

    public void flipLeft() {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(left());
        }
    }

    private IEnumerator right() {
        float increment = 0;
        while (increment < 100)
        {
            yield return null;
            smr.SetBlendShapeWeight(0, increment);
            increment += speed * Time.deltaTime;
        }

        smr.SetBlendShapeWeight(0, 0);
        smr.SetBlendShapeWeight(1, 100);
        increment = 100;
        while (increment > 0) {
            yield return null;
            smr.SetBlendShapeWeight(1, increment);
            increment -= speed * Time.deltaTime;
        }
        smr.SetBlendShapeWeight(1, 0);
        yield return null;
        isRunning = false;
    }

    private IEnumerator left() {
        float increment = 0;
        while (increment < 100)
        {
            yield return null;
            smr.SetBlendShapeWeight(1, increment);
            increment += speed * Time.deltaTime;
        }

        smr.SetBlendShapeWeight(1, 0);
        smr.SetBlendShapeWeight(0, 100);
        increment = 100;
        while (increment > 0)
        {
            yield return null;
            smr.SetBlendShapeWeight(0, increment);
            increment -= speed * Time.deltaTime;
        }
        smr.SetBlendShapeWeight(0, 0);
        yield return null;
        isRunning = false;
    }
}
