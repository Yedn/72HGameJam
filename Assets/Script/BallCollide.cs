using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallCollide : MonoBehaviour
{   
    private Rigidbody2D rigid_ball;

    static public int Ascare = 0;
    static public int Bscare = 0;

    public Vector2 prepos = new Vector2(0.0f,0.0f);

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = prepos;
        
        rigid_ball = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Collider = collision.gameObject;
        Rigidbody2D rigid_collider = Collider.GetComponent<Rigidbody2D>();
        if (Collider.tag == "ADoor" || Collider.tag == "BDoor")
        {
            this.transform.position= prepos;
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
}
