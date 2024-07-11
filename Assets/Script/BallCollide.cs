using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class BallCollide : MonoBehaviour
{   
    private Rigidbody2D rigid_ball;
    static public bool isgoal = false;
    static public int Ascare = 0;
    static public int Bscare = 0;

    public Vector2 prepos = new Vector2(0.0f,0.0f);

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = prepos;
        
        rigid_ball = this.GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Collider = collision.gameObject;
        Rigidbody2D rigid_collider = Collider.GetComponent<Rigidbody2D>();
        if (Collider.CompareTag("ADoor") || Collider.CompareTag("BDoor"))
        {
            DieSound.BallInGate();
            ResetBallPos();
            rigid_ball.velocity = new Vector2(0f, 0f);
            isgoal = true;
            if (Collider.tag == "ADoor")
            {
                Bscare++;
            }
            else
            {
                Ascare++;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBallPos()
    {
        transform.position = prepos;
    }


}
