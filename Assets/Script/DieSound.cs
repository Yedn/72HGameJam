using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSound : MonoBehaviour
{
    public static AudioClip died;
    public static AudioClip goal;

    public static AudioSource aSou;
    // Start is called before the first frame update
    void Start()
    {
        died = Resources.Load<AudioClip>("DDD");
        goal = Resources.Load<AudioClip>("goal");
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

    public static void BallInGate()
    {
        aSou.PlayOneShot(goal);
    }

}
