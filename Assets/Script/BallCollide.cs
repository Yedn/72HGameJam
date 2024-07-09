using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallCollide : MonoBehaviour
{   
    private Rigidbody2D rigid_ball;

    public int Ascare = 0;
    public int Bscare = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector2(0, 0);
        rigid_ball = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Collider = collision.gameObject;
        Rigidbody2D rigid_collider = Collider.GetComponent<Rigidbody2D>();
        if (Collider.tag == "ADoor" || Collider.tag == "BDoor")
        {
            Destroy(this);
            if (Collider.tag == "ADoor")
            {
                
            }
        }
        else
        {
            rigid_ball.AddForce(rigid_collider.velocity * 4 / 3, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
