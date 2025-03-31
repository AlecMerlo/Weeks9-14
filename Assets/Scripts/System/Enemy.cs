using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject player;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // difficulty goes up if enemy not killed
        speed += Time.deltaTime * 0.05f;
        transform.position += -(transform.position - player.transform.position).normalized * Time.deltaTime * speed;
    }
}
