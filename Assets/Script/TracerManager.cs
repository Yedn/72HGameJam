using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏管理器
/// </summary>
public class TracerManager : MonoBehaviour
{

    public int maxforce=1;//

    /// <summary>
    /// 鸟
    /// </summary>
    public Bird bird;
    /// <summary>
    /// 轨迹预测器
    /// </summary>
    public Trajectory trajectory;

    /// <summary>
    /// 主摄像机
    /// </summary>
    private Camera m_cam;

    /// <summary>
    /// 力大小
    /// </summary>
    [SerializeField]
    private float m_speedFactor = 4f;

    /// <summary>
    /// 是否拉动中
    /// </summary>
    [HideInInspector] private bool m_isDragging = false;
    /// <summary>
    /// 手指的起始点
    /// </summary>
    private Vector2 m_startPoint;
    /// <summary>
    /// 手指的结束点
    /// </summary>
    private Vector2 m_endPoint;
    /// <summary>
    /// 起始点和结束点的距离
    /// </summary>
    private float m_distance;
    /// <summary>
    /// 方向向量，从结束点指向起始点的归一化向量
    /// </summary>
    private Vector2 m_direction;
    /// <summary>
    /// 力向量
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
            // 检测鼠标/手指行为
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
    /// 开始拉
    /// </summary>
    private void OnDragStart()
    {
        // 禁用物理
        bird.DesActivateRb();
        // 起始点
        m_startPoint = m_cam.ScreenToWorldPoint(Input.mousePosition);
        // 显示轨迹
        trajectory.Show();
    }

    /// <summary>
    /// 拉中
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
    /// 拉结束
    /// </summary>
    private void OnDragEnd()
    {
        bird.ActivateRb();
        Debug.Log("Trace:" + bird.GetComponent<Rigidbody2D>().isKinematic);
        bird.Push(m_pushSpeed);
        // 隐藏轨迹
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

