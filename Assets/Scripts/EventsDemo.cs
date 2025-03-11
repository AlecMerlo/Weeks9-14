using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventsDemo : MonoBehaviour
{
    bool thing;
    public Image bananaImg;
    float speed;
    //public UnityEvent TimerHasFinished;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (thing)
        {
            speed = bananaImg.transform.localScale.x;
            transform.position += (transform.position - Input.mousePosition).normalized * 2 * speed;
        }
        else
        {
            if (bananaImg.transform.localScale.x > 0.5f)
            {
                bananaImg.transform.localScale -= Vector3.one / 50;
            }
            bananaImg.transform.position -= (transform.localPosition).normalized * 3;
        }
    }

    public void IJustPushedTheButton()
    {
        Debug.Log("IJustPushedTheButton");
    }

    public void IAlsoPushedTheButton()
    {
        Debug.Log("Me too!");
    }

    public void BananaRun()
    {
        thing = true;
    }
    public void Laugh()
    {
        thing = false;
        Debug.Log("Haha!");
    }

    public void Grow()
    {
        bananaImg.transform.localScale += Vector3.one / 10;
        Debug.Log("Nooo!!");
    }
}
