using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.InputSystem;


public class control : MonoBehaviour
{
    SpriteRenderer sprite;

    public Rigidbody2D rigid;
    public Collider2D col;
    public Vector3 pos
    {
        get { return transform.position; }
    }


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void Push(Vector2 speed)
    {
        rigid.AddForce(speed,ForceMode2D.Impulse);
    }

    public void ActivateRigid()
    {
        rigid.isKinematic = false;
    }

    private void OnMouseEnter()
    {
        sprite.color = new Vector4(0.8f, 0.8f, 0.8f, 1);
    }

    public void DesActivateRigid()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = 0f;
        rigid.isKinematic = true;
    }

    private void OnMouseLeave()
    {
        sprite.color = new Vector4(1, 1, 1, 1);
    }



    private bool choose()
    {

        var mouse = Mouse.current;
        if (mouse == null)
        {
            return false;
        }

        if (mouse.leftButton.wasPressedThisFrame)
        {
            var onScreenPosition = mouse.position.ReadValue();
            var ray = Camera.main.ScreenPointToRay(onScreenPosition);

            var hit = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.transform.position = ray.origin;
            }
            return true;
        }
        return false;
    }





    // Update is called once per frame
    void Update()
    {
        OnMouseEnter();
        OnMouseLeave();

    }
}
