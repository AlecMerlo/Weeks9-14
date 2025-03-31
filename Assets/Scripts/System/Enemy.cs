using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;
    public GameObject player;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += -(transform.position - player.transform.position).normalized * Time.deltaTime * speed;
    }
}
