using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏管理器
/// </summary>
public class TracerManager
    : MonoBehaviour
{
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
    private bool m_isDragging = false;
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

    private void Start()
    {
        m_cam = Camera.main;
        //bird.DesActivateRb();
        bird.ActivateRb();
    }

    private void Update()
    {
        if (IsChoen)
        {
            // 检测鼠标/手指行为
            if (Input.GetMouseButtonDown(0))
            {
                m_isDragging = true;
                OnDragStart();
                AvoidLeftCheck = true;
            }
            if (Input.GetMouseButtonUp(0) && AvoidLeftCheck)
            {
                m_isDragging = false;
                OnDragEnd();
                AvoidLeftCheck = false;
            }

            if (m_isDragging)
            {
                OnDrag();
            }
        }
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
        m_endPoint = m_cam.ScreenToWorldPoint(Input.mousePosition);
        m_distance = Vector2.Distance(m_startPoint, m_endPoint);
        m_direction = (m_startPoint - m_endPoint).normalized;
        m_distance = Mathf.Min(m_distance, 6.0f);
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
        bird.Push(m_pushSpeed);
        // 隐藏轨迹
        trajectory.Hide();
    }
}

