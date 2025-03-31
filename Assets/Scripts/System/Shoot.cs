using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject laserObj;
    private float timer;
    public float charge;
    public float shootTime;
    private IEnumerator chargeUp;
    private IEnumerator laserShot;


    void Update()
    {
        // gets the shootable enemy and makes em red
        if(GameObject.Find("Enemy(Clone)") != null)
        {
            GameObject.Find("Enemy(Clone)").GetComponent<SpriteRenderer>().color = Color.red;
        }
        // shoot
        //pistol();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargeUp = ChargeUp();
            StartCoroutine(chargeUp);
        }
    }

    void pistol()
    {
        //shoot
        if (Input.GetKey(KeyCode.Space) && timer < 0.1f)
        {
            timer = 0.4f;
            bullet.SetActive(true);
            Instantiate(bullet);
            bullet.SetActive(false);
        }
        // time between firing
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, Mathf.Infinity);
    }

    IEnumerator ChargeUp()
    {
        while (charge < 5 && Input.GetKey(KeyCode.Space))
        {
            laserObj.transform.GetChild(0).transform.localPosition += Vector3.up * Time.deltaTime * 0.1f;
            laserObj.transform.GetChild(1).transform.localPosition -= Vector3.up * Time.deltaTime * 0.1f;
            charge += Time.deltaTime;
            yield return null;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            laserShot = LaserShoot();
            StartCoroutine(laserShot);
        }
        charge = 0;
        laserObj.transform.GetChild(0).transform.localPosition = Vector3.up * 0.5f;
        laserObj.transform.GetChild(1).transform.localPosition = Vector3.up * -0.5f;
    }

    IEnumerator LaserShoot()
    {
        while (shootTime < 0.5f)
        {
            bullet.SetActive(true);
            Instantiate(bullet);
            bullet.SetActive(false);
            shootTime += Time.deltaTime;
            yield return null;
        }
        shootTime = 0;
    }
}
