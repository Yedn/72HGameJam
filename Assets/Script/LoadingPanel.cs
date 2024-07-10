using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    bool isLoadCompleted = true;
    AsyncOperation asyncOperation;
    public Text loadingtext;
    public LoadingUI loadingUI;
    void Awake() { 
        loadingUI.FillAmount = 0;
        StartCoroutine(LoadingCoroutime());
        Update();
    }

IEnumerator LoadingCoroutime()
{
    asyncOperation = SceneManager.LoadSceneAsync("test1");

    asyncOperation.allowSceneActivation = false;

    while(loadingUI.FillAmount<1)
    {
        loadingtext.text = "哦哈呦";

        loadingUI.targetFillAmount = asyncOperation.progress+0.1f;

        yield return null;
    }
    loadingUI.FillAmount = 1;
    loadingtext.text = "点击以继续";
    isLoadCompleted = false;

}
    void Update()
    {
        if(isLoadCompleted) return;
        if(Input.anyKey)
        {
            Debug.Log("Enable transform");
            asyncOperation.allowSceneActivation = true;
        }
    } 
}
