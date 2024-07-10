using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ϸ������
/// </summary>
public class TracerManager : MonoBehaviour
{

    public int maxforce=1;//

    /// <summary>
    /// ��
    /// </summary>
    public Bird bird;
    /// <summary>
    /// �켣Ԥ����
    /// </summary>
    public Trajectory trajectory;

    /// <summary>
    /// �������
    /// </summary>
    private Camera m_cam;

    /// <summary>
    /// ����С
    /// </summary>
    [SerializeField]
    private float m_speedFactor = 4f;

    /// <summary>
    /// �Ƿ�������
    /// </summary>
    [HideInInspector] private bool m_isDragging = false;
    /// <summary>
    /// ��ָ����ʼ��
    /// </summary>
    private Vector2 m_startPoint;
    /// <summary>
    /// ��ָ�Ľ�����
    /// </summary>
    private Vector2 m_endPoint;
    /// <summary>
    /// ��ʼ��ͽ�����ľ���
    /// </summary>
    private float m_distance;
    /// <summary>
    /// �����������ӽ�����ָ����ʼ��Ĺ�һ������
    /// </summary>
    private Vector2 m_direction;
    /// <summary>
    /// ������
    /// </summary>
    private Vector2 m_pushSpeed;


    private bool IsChoen = false;
    private bool AvoidLeftCheck = false;
    private bool moved = false;
    //private Rigidbody2D rb;

    private void Start()
    {
        m_cam = Camera.main;
        //bird.DesActivateRb();
        bird.ActivateRb();
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsChoen)
        {
            // ������/��ָ��Ϊ
            if (Input.GetMouseButtonDown(0) && GameManager.canAction)
            {
                m_isDragging = true;
                OnDragStart();
                AvoidLeftCheck = true;
                GameManager.isRelease = false;
            }
            if (Input.GetMouseButtonUp(0) && AvoidLeftCheck)
            {
                GameManager.isRelease = true;
                m_isDragging = false;
                OnDragEnd();
                AvoidLeftCheck = false;
                moved = true;
                //bird.GetComponent<ClickDetector>().SetcanSelect(true);
            }

            if (m_isDragging)
            {
                bird.GetComponent<ClickDetector>().SetcanUnSelect(false);
                GameManager.canAction = false;
                OnDrag();
            }
        }
        CheckTurn();
    }

    public void SetChosen(bool B)
    {
        this.IsChoen = B;
    }


    /// <summary>
    /// ��ʼ��
    /// </summary>
    private void OnDragStart()
    {
        // ��������
        bird.DesActivateRb();
        // ��ʼ��
        m_startPoint = m_cam.ScreenToWorldPoint(Input.mousePosition);
        // ��ʾ�켣
        trajectory.Show();
    }

    /// <summary>
    /// ����
    /// </summary>
    private void OnDrag()
    {
        maxforce = AForce.randomforce;
        m_endPoint = m_cam.ScreenToWorldPoint(Input.mousePosition);
        m_distance = Vector2.Distance(m_startPoint, m_endPoint);
        m_direction = (m_startPoint - m_endPoint).normalized;
        m_distance = Mathf.Min(m_distance, maxforce);
        //Debug.Log(m_distance);

        m_pushSpeed = m_direction * m_distance * m_speedFactor;

        trajectory.UpdateDots(bird.pos, m_pushSpeed);
    }

    /// <summary>
    /// ������
    /// </summary>
    private void OnDragEnd()
    {
        bird.ActivateRb();
        Debug.Log("Trace:" + bird.GetComponent<Rigidbody2D>().isKinematic);
        bird.Push(m_pushSpeed);
        // ���ع켣
        trajectory.Hide();
    }


    public event Action OutGate;
    public void CheckTurn()
    {
        bool isStandBy = bird.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f;
        if(isStandBy && moved)
        {
            GameManager.teamlist[0] = !GameManager.teamlist[0];
            GameManager.teamlist[1] = !GameManager.teamlist[1];
            bird.GetComponent<ClickDetector>().SetcanUnSelect(true);
            GameManager.canAction = true;
            moved = false;
            OutGate?.Invoke();
        }
    }

}

