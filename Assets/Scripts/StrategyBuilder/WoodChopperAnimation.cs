using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChopperAnimation : MonoBehaviour
{
    public AnimationCurve curve;
    GameObject groundObj;
    GameObject restOfTheBox;
    GameObject flap1, flap2;
    IEnumerable spawnObj;
    float t = 0;
    private void Start()
    {
        groundObj = transform.GetChild(0).gameObject;
        restOfTheBox = transform.GetChild(1).gameObject;
        flap1 = restOfTheBox.transform.GetChild(4).transform.GetChild(0).gameObject;
        flap2 = restOfTheBox.transform.GetChild(4).transform.GetChild(1).gameObject;

        StartCoroutine(chopperSpawn());
    }

    private IEnumerator chopperSpawn()
    {
        t = 0;
        yield return StartCoroutine(step1());
        t = 0;
        yield return StartCoroutine(step2());
        t = 0;
        yield return StartCoroutine(step3());
    }

    private IEnumerator step1()
    {
        while (t < 4)
        {
            t += Time.deltaTime;
            groundObj.transform.localPosition = Vector3.up * 1.05f * curve.Evaluate(t / 4);
            yield return null;
        }
    }

    private IEnumerator step2()
    {
        while (t < 4)
        {
            t += Time.deltaTime;
            restOfTheBox.transform.localPosition = Vector3.up * curve.Evaluate(t / 4);
            yield return null;
        }
    }

    private IEnumerator step3()
    {
        while (t < 4)
        {
            t += Time.deltaTime;
            flap1.transform.Rotate(new Vector3(-0.2f * curve.Evaluate((t / 4)), 0, 0));
            flap2.transform.Rotate(new Vector3(0.2f * curve.Evaluate((t / 4)), 0, 0));
            yield return null;
        }
    }
}
