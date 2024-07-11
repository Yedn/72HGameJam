using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumnControler : MonoBehaviour
{
    public static bool isLoad = false;
    // Start is called before the first frame update
    void Start()
    {
      if(!isLoad)
      {
        isLoad = true;
        DontDestroyOnLoad(gameObject);
      }
      else  {
        Destroy(gameObject);
        return;
        }
    }

    // Update is called once per frame
    void Update()
    {
      UpDateGameObject();
      GetGameObjectValue();
    }

    public void UpDateGameObject()  {
      UnityEngine.SceneManagement.Scene activeScene = SceneManager.GetActiveScene();
      if(activeScene.name == "Mainmenu")
      {
        GameObject BGM = GameObject.Find("BGM").transform.gameObject;
        GameObject audioSlider = GameObject.FindGameObjectWithTag("GameSettingUI").transform.GetChild(0).GetChild(0).gameObject; 
        PlayerPrefs.SetFloat("audioVolume",audioSlider.GetComponent<Slider>().value);
        BGM.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("audioVolume");
        print(PlayerPrefs.GetFloat("audioVolume"));
      }
    
    } 

    public void GetGameObjectValue()  {
      UnityEngine.SceneManagement.Scene activeScene = SceneManager.GetActiveScene();
      if(activeScene.name == "test1")
      {
        GameObject BGM = GameObject.Find("BGM").transform.gameObject;
        BGM.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("audioVolume");
      }


    }

   
}
