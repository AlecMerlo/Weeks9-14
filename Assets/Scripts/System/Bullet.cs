using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    public GameObject player;
    public GameObject enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        if (transform.position.x > 9 || transform.position.x < -9 || transform.position.y > 7 || transform.position.y < -7)
        {
            Destroy(gameObject);
        }
        else if (GameObject.Find("Enemy(Clone)") != null && Vector3.Distance(transform.position, GameObject.Find("Enemy(Clone)").transform.position) < 0.5f)
        {
            Destroy(GameObject.Find("Enemy(Clone)"));
            enemySpawner.GetComponent<SpawnEnemy>().enemiesLeft -= 1;
            Destroy(gameObject);
        }
    }
}
