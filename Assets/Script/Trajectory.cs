using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    /// <summary>
    /// Ԥ��������
    /// </summary>
    [SerializeField] private int m_dotsNum = 20;
    /// <summary>
    /// ������ĸ��ڵ�
    /// </summary>
    [SerializeField] private GameObject m_dotsParent;
    /// <summary>
    /// ��Ԥ��
    /// </summary>
    [SerializeField] private GameObject m_dotsPrefab;
    /// <summary>
    /// ����
    /// </summary>
    [SerializeField] private float m_dotSpacing = 0.01f;
    /// <summary>
    /// �����С����
    /// </summary>
    [SerializeField] [Range(0.01f, 0.3f)] private float m_dotMinScale = 0.1f;
    /// <summary>
    /// ����������
    /// </summary>
    [SerializeField] [Range(0.3f, 1f)] private float m_dotMaxScale = 1f;


    private Transform[] m_dotsList;
    private Vector2 m_pos;
    private float m_timeStamp;

    private void Start()
    {
        Hide();
        PrepareDots();
    }

    /// <summary>
    /// ׼���켣��
    /// </summary>
    private void PrepareDots()
    {
        m_dotsList = new Transform[m_dotsNum];
        m_dotsPrefab.transform.localScale = Vector3.one * m_dotMaxScale;
        float scale = m_dotMaxScale;
        float scaleFactor = scale / m_dotsNum;

        for (int i = 0; i < m_dotsNum; ++i)
        {
            var dot = Instantiate(m_dotsPrefab).transform;
            dot.parent = m_dotsParent.transform;
            dot.localScale = Vector3.one * scale;
            if (scale > m_dotMinScale)
                scale -= scaleFactor;
            m_dotsList[i] = dot;
        }
    }

    public void UpdateDots(Vector2 birdPos, Vector2 pushSpeed)
    {
        m_timeStamp = m_dotSpacing;

        for (int i = 0; i < m_dotsNum; ++i)
        {
            m_pos.x = birdPos.x + pushSpeed.x * m_timeStamp;
            m_pos.y = (birdPos.y + pushSpeed.y * m_timeStamp) - 0.5f * Physics2D.gravity.magnitude * m_timeStamp * m_timeStamp;
            m_dotsList[i].position = m_pos;
            m_timeStamp += m_dotSpacing;
        }
    }

    public void Show()
    {
        m_dotsParent.SetActive(true);
    }

    /// <summary>
    /// ����Ԥ��켣
    /// </summary>
    public void Hide()
    {
        m_dotsParent.SetActive(false);
    }
}
