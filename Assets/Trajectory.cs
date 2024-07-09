using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    // Start is called before the first frame update

    public int dotsNum = 10; //预测点的数量
    public GameObject dotsParent;
    public GameObject dotsPrefab;
    public float dotsSpacing = 0.02f; // 点间间距
    [Range(0.01f,0.3f)] public float dotMinSize  = 0.1f;
    [Range(0.3f, 1f)] public float dotMaxSize = 1f;

    private Transform[] dotsList;
    private Vector2 pos;
    private float timeStamp;

    void Start()
    {
        Hide();
        PrepareDots();
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }

    private void PrepareDots()
    {
        dotsList = new Transform[dotsNum];
        dotsPrefab.transform.localScale = Vector3.one*dotMaxSize;
        float size = dotMaxSize;
        float sizeFactor = size / dotsNum;

        for (int i=0;i<dotsNum; i++)
        {
            var dot = Instantiate(dotsPrefab).transform;
            dot.parent = dotsParent.transform;
            dot.localScale = Vector3.one * size;
            if (size >dotMinSize)
            {
                size -= sizeFactor;
            }
            dotsList[i] = dot;
        }
    }

    public void UpdateDots (Vector2 birdPos, Vector2 pushSpeed)
    {
        timeStamp = dotsSpacing;
        for (int i=0;i<dotsNum; i++) 
        {
            pos.x = birdPos.x + pushSpeed.x*timeStamp;
            pos.y = birdPos.y + pushSpeed.y * timeStamp;
            dotsList[i].position = pos;
            timeStamp += dotsSpacing;
        }
    }
    // Update is called once per frame
}
