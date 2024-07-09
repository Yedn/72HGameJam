using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickDetector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键是否被按下  
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("你点击了物体: " + hit.collider.name);
                // 在这里添加你希望执行的代码  
                GameObject eff = transform.Find("NormalChosenEffect").gameObject;
                eff.SetActive(true);
            }
        }
    }
}