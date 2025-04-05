using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemy : MonoBehaviour
{
    public int enemyAmount = 1;
    public int enemiesLeft;
    public GameObject enemy;
    public TextMeshPro amountText;
    public Shoot shoot;
    UnityEvent laserBuff;

    void Start()
    {
        // creating the listener for making the laser stronger on kill
        if (laserBuff == null)
        {
            laserBuff = new UnityEvent();
            laserBuff.AddListener(shoot.MakeLaserStronk);
        }
    }

    void Update()
    {
        // creating the new wave of enemies once all enemies on screen are eliminated
        if(enemiesLeft == 0)
        {
            // set active so I don't need to do it for every enemy later
            enemy.SetActive(true);
            for(int i = 0; i < enemyAmount; i++)
            {
                // spawn just a little past borders
                if(Random.Range(0,2) == 0)
                {
                    if(Random.Range(0, 2) == 0)
                    {
                        Instantiate(enemy, new Vector3(Random.Range(-7.5f, 7.5f), 6, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(enemy, new Vector3(Random.Range(-7.5f, 7.5f), -6, 0), Quaternion.identity);
                    }
                }
                else
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        Instantiate(enemy, new Vector3(7.5f, Random.Range(-6f,6f), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(enemy, new Vector3(-7.5f, Random.Range(-6f, 6f), 0), Quaternion.identity);
                    }
                }
                // making it so that the next wave will have one more enemy (and so that enemies won't go to 0 or below, breaking the game)
                enemiesLeft += 1;
            }
            laserBuff.Invoke();
            enemy.SetActive(false);
            enemyAmount += 1;
            amountText.text = enemiesLeft.ToString();
        }
    }
}
