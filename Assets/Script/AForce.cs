using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AForce : MonoBehaviour
{
    static public int randomforce = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int MaxForce()
    {
        return Random.Range(0, 7);
    }

    public void maxForce()
    {
        randomforce = Random.Range(1, 7);
        Debug.Log("MaxForce = " + randomforce);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
