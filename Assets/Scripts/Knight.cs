using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class Knight : MonoBehaviour
{
    public float speed = 4f;
    Animator animator;
    SpriteRenderer sr;
    public bool canRun = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float dir = 0;
        if (canRun)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
            {
                dir = Input.GetAxisRaw("Horizontal");
                sr.flipX = dir < 0;
            }

            animator.SetFloat("speed", Mathf.Abs(dir));

            if (Input.GetMouseButtonDown(0))
            {
                canRun = false;
                animator.SetTrigger("attack");
            }

            transform.position += Vector3.right * dir * speed * Time.deltaTime;
        }
    }

    public void AttackHasFinished()
    {
        canRun = true;
    }
}
