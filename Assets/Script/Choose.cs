using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Choose : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("in");
        GameObject eff = transform.Find("NormalChosenEffect").gameObject;
        eff.SetActive(true);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //你要触发的代码
    }
}
