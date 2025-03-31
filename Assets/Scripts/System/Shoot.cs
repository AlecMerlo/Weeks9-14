using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    float timer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && timer < 0.1f)
        {
            timer = 0.4f;
            bullet.SetActive(true);
            Instantiate(bullet);
            bullet.SetActive(false);
        }
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, Mathf.Infinity);
    }
}
