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
        Debug.Log(rb.isKinematic == true);
    }

    public void Push(Vector2 speed)
    {
        rb.AddForce(speed, ForceMode2D.Impulse);
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
    }



}
