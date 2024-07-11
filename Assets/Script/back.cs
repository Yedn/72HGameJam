using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class back : MonoBehaviour
{
    // Start is called before the first frame update
    public Image AImage;
    public Image BImage;
    private Color color;
    void Start()
    {
        //AImage = GetComponent<Image>();
        //BImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.teamlist[1])
        {
            color = AImage.color;
            color.a = 0.5f;
            AImage.color = color;
            color = BImage.color;
            color.a = 1.0f;
            BImage.color = color;
        }
        else
        {
            color = AImage.color;
            color.a = 1.0f;
            AImage.color = color;
            color = BImage.color;
            color.a = 0.5f;
            BImage.color = color;
        }
    }
}
