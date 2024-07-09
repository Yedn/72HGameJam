using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickDetector : MonoBehaviour
{
    private bool isTurn = false;
    private bool isChosen = false;
    private GameObject eff;
    private string Corename;

    private void Awake()
    {
        Corename = transform.parent.name;
    }

    void Update()
    {
        if (isTurn)
        {
            Chosen();
        }
    }

    public bool getChosenState()
    {
        return this.isChosen;
    }

    private void Chosen()
    {
        if (Input.GetMouseButtonDown(0)) // ����������Ƿ񱻰���  
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Debug.Log("out");
            if (hit.collider != null)
            {
                //Debug.Log("in");
                if (hit.collider.transform.parent.name == Corename)
                {
                    Debug.Log("����������: " + hit.collider.name + transform.parent.name);
                    // �����������ϣ��ִ�еĴ���  
                    eff = hit.collider.gameObject.transform.Find("NormalChosenEffect").gameObject;
                    //if (eff.activeSelf)
                    //{
                    //    eff.SetActive(false);
                    //    isChosen = false;
                    //}
                    //else
                    //{
                    //    eff.SetActive(true);
                    //    isChosen = true;
                    //}
                    isChosen = true;
                    eff.SetActive(true);
                }
            }
        }
    }

    public void UnChosen()
    {
        isChosen = false;
        transform.Find("NormalChosenEffect").gameObject.SetActive(false);
    }

    public void SetTurn(bool tt)
    {
        isTurn = tt;
    }
}