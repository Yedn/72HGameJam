using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AteamScare : MonoBehaviour
{

    private Text Ateam;
    // Start is called before the first frame update
    void Start()
    {
        Ateam = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Ateam.text = BallCollide.Ascare.ToString()+"/5";
    }
}
