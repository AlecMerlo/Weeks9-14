using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float speed;
    bool killed;
    public GameObject player;
    public GameObject enemySpawner;
    public Shoot shoot;
    public TextMeshPro amountText;
    UnityEvent laserBuff;

    void Start()
    {
        // listener
        if (laserBuff == null)
        {
            laserBuff = new UnityEvent();
            laserBuff.AddListener(shoot.MakeLaserStronk);
        }
    }

    void FixedUpdate()
    {
        // difficulty goes up if enemy not killed
        speed += Time.deltaTime * (0.02f * enemySpawner.GetComponent<SpawnEnemy>().enemyAmount);
        // move towards player
        transform.position += -(transform.position - player.transform.position).normalized * Time.deltaTime * speed;

        // if player touching, lower enemy amount by 1 and destroy enemy
        if (Vector3.Distance(transform.position, player.transform.position) < 0.9f)
        {
            enemySpawner.GetComponent<SpawnEnemy>().enemyAmount -= 1;
            enemySpawner.GetComponent<SpawnEnemy>().enemiesLeft -= 1;
            amountText.text = enemySpawner.GetComponent<SpawnEnemy>().enemyAmount.ToString();
            laserBuff.Invoke();
            Destroy(gameObject);
        }
    }

    public void kill()
    {
        // destroying killed enemies and changing the value of enemies left
        if(GameObject.Find("Enemy(Clone)") == this.gameObject && killed == false)
        {
            killed = true;
            enemySpawner.GetComponent<SpawnEnemy>().enemiesLeft -= 1;
            Destroy(gameObject);
        }
    }
}
