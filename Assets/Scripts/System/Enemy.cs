using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject player;

    void FixedUpdate()
    {
        // difficulty goes up if enemy not killed
        speed += Time.deltaTime * 0.05f;
        // move towards player
        transform.position += -(transform.position - player.transform.position).normalized * Time.deltaTime * speed;
    }

    private void Update()
    {
        // if player touching
        if(Vector3.Distance(transform.position, player.transform.position) < 0.9f)
        {
            Debug.Log("womp womp");
        }
    }
}
