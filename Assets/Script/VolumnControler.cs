using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumnControler : MonoBehaviour
{
    public AudioSource BGMAudio;
    public Slider volumnslider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      BGMAudio.volume = volumnslider.value;  
    }

}
