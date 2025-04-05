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
        // a bunch of timers
        // making the laser weaker over time
        laserLength -= 0.02f * Time.deltaTime;
        laserLength = Mathf.Clamp(laserLength, 0.05f, 1f);
        // making the text get smaller over time
        t.transform.localScale -= Vector3.one * Time.deltaTime;
        temp = new Vector3(Mathf.Clamp(t.transform.localScale.x, 1.4f, 2f), Mathf.Clamp(t.transform.localScale.y, 1.4f, 2f), Mathf.Clamp(t.transform.localScale.z, 1.4f, 2f));
        t.transform.localScale = temp;
        // making the text more transparent over time
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
                // hide pistol and show laser
                player.transform.GetChild(0).gameObject.SetActive(false);
                player.transform.GetChild(1).gameObject.SetActive(true);
                usingPistol = false;
            }
            else
            {
                // reset position of laser gun parts and charge
                charge = 0;
                laserObj.transform.GetChild(0).transform.localPosition = Vector3.up * 0.5f;
                laserObj.transform.GetChild(1).transform.localPosition = Vector3.up * -0.5f;
                // hide laser and show pistol
                player.transform.GetChild(0).gameObject.SetActive(true);
                player.transform.GetChild(1).gameObject.SetActive(false);
                usingPistol = true;
                // to make the charge attack of the laser not transfer to the code of the pistol
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
        // creating copies of the bullet (shooting them)
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

    // laser weapon charging up (with animation) and shooting
    IEnumerator ChargeUp()
    {
        while (charge < 1.5f && Input.GetKey(KeyCode.Space))
        {
            // charging up and animation (making the gun look like it's opening up)
            laserObj.transform.GetChild(0).transform.localPosition += Vector3.up * Time.deltaTime * 0.4f;
            laserObj.transform.GetChild(1).transform.localPosition -= Vector3.up * Time.deltaTime * 0.4f;
            charge += Time.deltaTime;
            yield return null;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // shoot the laser
            laserShot = LaserShoot();
            StartCoroutine(laserShot);
        }
        // reset position of laser gun parts and charge
        charge = 0;
        laserObj.transform.GetChild(0).transform.localPosition = Vector3.up * 0.5f;
        laserObj.transform.GetChild(1).transform.localPosition = Vector3.up * -0.5f;
    }

    IEnumerator LaserShoot()
    {
        // using the same thing as the pistol shooting, just done many times in a short period of time
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
        // makes the laser last longer
        laserLength += 0.05f;
        t.transform.localScale += Vector3.one * 0.2f;
        t.alpha = 1f;
    }
}
