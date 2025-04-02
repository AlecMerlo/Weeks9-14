using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject laserObj;
    public GameObject player;
    public TextMeshPro t;
    private Vector3 temp;
    public float laserLength;
    private float timer;
    private float charge;
    private float shootTime;
    public bool usingPistol = true;
    private IEnumerator chargeUp;
    private IEnumerator laserShot;
    

    void Update()
    {
        laserLength -= 0.02f * Time.deltaTime;
        laserLength = Mathf.Clamp(laserLength, 0.05f, 1f);

        t.transform.localScale -= Vector3.one * Time.deltaTime;
        temp = new Vector3(Mathf.Clamp(t.transform.localScale.x, 1.4f, 2f), Mathf.Clamp(t.transform.localScale.y, 1.4f, 2f), Mathf.Clamp(t.transform.localScale.z, 1.4f, 2f));
        t.transform.localScale = temp;

        t.alpha -= Time.deltaTime * 2;
        t.alpha = Mathf.Clamp(t.alpha, 0.2f, 0.7f);

        // gets the shootable enemy and makes em red
        if (GameObject.Find("Enemy(Clone)") != null)
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
                StopAllCoroutines();
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
        while (charge < 1.5f && Input.GetKey(KeyCode.Space))
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
        while (shootTime < 0.05f + laserLength)
        {
            bullet.SetActive(true);
            Instantiate(bullet);
            bullet.SetActive(false);
            shootTime += Time.deltaTime;
            yield return null;
        }
        shootTime = 0;
    }

    public void MakeLaserStronk()
    {
        laserLength += 0.05f;
        t.transform.localScale += Vector3.one * 0.2f;
        t.alpha = 1f;
    }
}
