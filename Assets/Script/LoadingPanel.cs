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

    while(loadingUI.FillAmount<0.3)
    {
        loadingtext.text = "“我将，点燃球场！”.";

        loadingUI.targetFillAmount = asyncOperation.progress+0.1f;

        yield return null;
    }
    while(loadingUI.FillAmount<0.6 && loadingUI.FillAmount>0.3)
    {
        loadingtext.text = "“国足会赢吗？”..";

        loadingUI.targetFillAmount = asyncOperation.progress+0.1f;

        yield return null;
    }
    while(loadingUI.FillAmount<1 && loadingUI.FillAmount>0.6)
    {
        loadingtext.text = "“会赢的”\n“等通知”...";

        loadingUI.targetFillAmount = asyncOperation.progress+0.1f;

        yield return null;
    }





    loadingUI.FillAmount = 1;
    loadingtext.text = "球赛，启动！\n (点击以继续)";
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
