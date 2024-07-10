using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    static public int random;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool OnButtonClick()
    {
        int random = Random.Range(0, 2);
        if (random == 0 )
        {
            Debug.Log("TeamA first");
        }
        else
        {
            Debug.Log("TeamB first");
        }
        return (random!=0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
