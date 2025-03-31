using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private int enemyAmount = 1;
    public int enemiesLeft;
    public GameObject enemy;

    void Update()
    {
        if(enemiesLeft == 0)
        {
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
                enemiesLeft += 1;
            }
            enemy.SetActive(false);
            enemyAmount += 1;
        }
    }
}
