using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxForce : MonoBehaviour
{
    static public int randomforce = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void maxForce()
    {
        randomforce = Random.Range(3, 7);
        Debug.Log("MaxForce = " + randomforce);
    }
    // Update is called once per frame
    void Update()
    {

    }
}