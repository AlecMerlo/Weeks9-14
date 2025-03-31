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

    void FixedUpdate()
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
        else if (Vector3.Distance(transform.position, GameObject.Find("Enemy(Clone)").transform.position) < 0.5f)
        {
            GameObject.Find("Enemy(Clone)").GetComponent<Enemy>().kill();
            Destroy(gameObject);
        }
    }
}
