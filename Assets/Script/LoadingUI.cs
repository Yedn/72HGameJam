using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    public float FillAmount{get=>m_Image.fillAmount;set=>m_Image.fillAmount=value;}
    public float targetFillAmount;
    public float speed;
    private Image m_image;
    public Image m_Image
    {
        get
        {
            if(m_image==null)
                m_image = GetComponent<Image>();
            return m_image;
        }
    }
    void Update()
    {
        if(m_Image == null) return;
        if(FillAmount+speed>targetFillAmount)
        {
            FillAmount = targetFillAmount;
        }
        else
        {
            FillAmount +=speed;
        }
        
    }

}
