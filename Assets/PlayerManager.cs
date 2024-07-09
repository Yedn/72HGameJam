using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool ischose;
    public PlayerControl players;
    public Trajectory trajectory;
    private Camera cam;
    public float speedFactor = 3.0f;//力的大小
    private bool isDragging = false;
    private Vector2 startpoint;
    private Vector2 endpoint;
    private float distance;
    private Vector2 direction;
    private Vector2 PushSpeed;
    void Start()
    {
        cam = Camera.main;
        players.DesActivateRigid();
        ischose = false;
    }

    // Update is called once per frame
    private void OnDragStart()
    {
        players.DesActivateRigid();
        startpoint=cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();
    }
    private void OnDragEnd()
    {
        players.ActivateRigid();
        players.Push(PushSpeed);
        
        trajectory.Hide();
    }

    private void OnDrag()
    {
        endpoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startpoint,endpoint);
        direction = (startpoint - endpoint).normalized;
        PushSpeed = direction*distance*speedFactor;
        trajectory.UpdateDots(players.pos, PushSpeed);
    }

    void Update()
    {
        if ( this.ischose)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
            }
            if (isDragging)
            {
                OnDrag();
            }
        }
    }

    public void Setbool(bool ischose)
    {
        this.ischose = ischose;
    }
}
