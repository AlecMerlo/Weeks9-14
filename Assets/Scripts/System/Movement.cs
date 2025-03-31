using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int movSpeed;
    public int rotSpeed;
    Vector3 movementDir;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        transform.position += movementDir * movSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-6,6), Mathf.Clamp(transform.position.y,-4.5f,4.5f), 0);

        transform.Rotate(0, 0, -rotSpeed * Input.GetAxisRaw("RotateHorizontal") * Time.deltaTime);
    }
}
