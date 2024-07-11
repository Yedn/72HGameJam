using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BteamScare : MonoBehaviour
{

    private Text Bteam;
    // Start is called before the first frame update
    void Start()
    {
        Bteam = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Bteam.text = BallCollide.Bscare.ToString();
    }
}
