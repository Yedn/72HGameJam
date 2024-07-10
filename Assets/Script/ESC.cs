using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class ESC : MonoBehaviour
{
    bool isOnSetting = true;
    public GameObject OnGameSetting;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isOnSetting)
        {
            Debug.Log("TimeFreezed");
            Time.timeScale = 0f;
            isOnSetting = false;
            OnGameSetting.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !isOnSetting)
        {
            Debug.Log("TimeDeFreezed");
            OnGameSetting.SetActive(false);
            Time.timeScale = 1f;
            isOnSetting = true; 
        }
        
    }

}
