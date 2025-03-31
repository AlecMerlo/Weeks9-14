using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    public GameObject player;
    public GameObject enemySpawner;

    void Start()
    {
        // go to player
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

    void Update()
    {
        // move forwards
        transform.position += transform.right * speed * Time.deltaTime;
        // destroy if border is passed
        if (transform.position.x > 9 || transform.position.x < -9 || transform.position.y > 7 || transform.position.y < -7)
        {
            Destroy(gameObject);
        }
        // destroy if hit enemy
        // also destroy enemy
        else if (GameObject.Find("Enemy(Clone)") != null && Vector3.Distance(transform.position, GameObject.Find("Enemy(Clone)").transform.position) < 0.5f)
        {
            Destroy(GameObject.Find("Enemy(Clone)"));
            enemySpawner.GetComponent<SpawnEnemy>().enemiesLeft -= 1;
            Destroy(gameObject);
        }
    }
}
