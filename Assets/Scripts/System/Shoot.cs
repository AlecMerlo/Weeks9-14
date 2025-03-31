using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject laserObj;
    public GameObject player;
    private float timer;
    private float charge;
    private float shootTime;
    private bool usingPistol = true;
    private IEnumerator chargeUp;
    private IEnumerator laserShot;
    

    void Update()
    {
        // gets the shootable enemy and makes em red
        if(GameObject.Find("Enemy(Clone)") != null)
        {
            GameObject.Find("Enemy(Clone)").GetComponent<SpriteRenderer>().color = Color.red;
        }

        // switch weapon
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (usingPistol)
            {
                player.transform.GetChild(0).gameObject.SetActive(false);
                player.transform.GetChild(1).gameObject.SetActive(true);
                usingPistol = false;
            }
            else
            {
                player.transform.GetChild(0).gameObject.SetActive(true);
                player.transform.GetChild(1).gameObject.SetActive(false);
                usingPistol = true;
            }
        }

        // shoot
        if (usingPistol)
        {
            pistol();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
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
        while (charge < 1 && Input.GetKey(KeyCode.Space))
        {
            laserObj.transform.GetChild(0).transform.localPosition += Vector3.up * Time.deltaTime * 0.4f;
            laserObj.transform.GetChild(1).transform.localPosition -= Vector3.up * Time.deltaTime * 0.4f;
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
