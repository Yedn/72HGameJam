using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickDetector : MonoBehaviour
{
    private bool isTurn = false;
    private bool isChosen = false;
    private GameObject eff;
    private string Corename;
    private string Fcorename;
    private bool canUnSelect = true;

    private void Awake()
    {
        Fcorename = transform.parent.name;
        Corename = transform.parent.parent.name;
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
        if (Input.GetMouseButtonDown(1) && canUnSelect && GameManager.canAction)  
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Debug.Log("out");
            if (hit.collider != null)
            {
                //Debug.Log("in");
                if (hit.collider.transform.parent.parent.name == Corename &&
                    hit.collider.transform.parent.name == Fcorename
                    )
                {
                    Debug.Log("你点击了物体: " + hit.collider.name + transform.parent.name);
                    // 在这里添加你希望执行的代码  
                    eff = hit.collider.gameObject.transform.Find("NormalChosenEffect").gameObject;
                    isChosen = true;
                    eff.SetActive(true);
                }
            }
            else
            {
                //Debug.Log("你没点击了物体: " + hit.collider.name + transform.parent.name);
                eff = transform.Find("NormalChosenEffect").gameObject;
                isChosen = false;
                eff.SetActive(false);
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
     
    public void SetcanUnSelect(bool tt)
    {
        canUnSelect = tt;
    }

}