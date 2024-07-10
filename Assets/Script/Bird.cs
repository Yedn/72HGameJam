using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector]
    public Vector3 pos
    {
        get { return transform.position; }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        //rb.isKinematic = false;
        //Debug.Log(rb.isKinematic == true);
    }

    public void Push(Vector2 speed)
    {
        rb.AddForce(speed, ForceMode2D.Impulse);
        Debug.Log("forece:" + speed.ToString());
    }


    public void ActivateRb()
    {
        rb.isKinematic = false;
        
    }

    public void DesActivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
        //Debug.Log(rb.isKinematic);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ADoor") || other.gameObject.CompareTag("BDoor"))
        {
            transform.parent.Find("TraceManager").GetComponent<TracerManager>().OutGate += desPlayer;
            rb.velocity = new Vector2(0f, 0f);
            if (GetComponent<ClickDetector>().getChosenState() == false) desPlayer();
            //Destroy(transform.parent.gameObject);
            //transform.parent.gameObject.SetActive(false);
        }
    }

    public void desPlayer()
    {
        transform.parent.gameObject.SetActive(false);
    }

}
