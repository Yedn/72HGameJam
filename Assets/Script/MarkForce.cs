using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MarkForce : MonoBehaviour
{

    private Text showtext;
    // Start is called before the first frame update
    void Start()
    {
        showtext = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        int finalnum = MaxForce.randomforce;
        showtext.text="最大力度：" +finalnum.ToString();
    }
}
