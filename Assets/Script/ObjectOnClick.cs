using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickDetector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ����������Ƿ񱻰���  
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("����������: " + hit.collider.name);
                // �����������ϣ��ִ�еĴ���  
                GameObject eff = transform.Find("NormalChosenEffect").gameObject;
                eff.SetActive(true);
            }
        }
    }
}