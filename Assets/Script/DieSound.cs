using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSound : MonoBehaviour
{
    public static AudioClip died;
    public static AudioSource aSou;
    // Start is called before the first frame update
    void Start()
    {
        died = Resources.Load<AudioClip>("DDD");
        aSou = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayerInGate()
    {
        aSou.PlayOneShot(died);
    }

}
