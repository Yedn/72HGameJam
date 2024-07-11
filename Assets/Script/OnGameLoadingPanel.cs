using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OnGameLoadingPanel : MonoBehaviour
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
    asyncOperation = SceneManager.LoadSceneAsync("MainMenu");

    asyncOperation.allowSceneActivation = false;

    while(loadingUI.FillAmount<0.3)
    {
        loadingtext.text = "观众正在退场.";

        loadingUI.targetFillAmount = asyncOperation.progress+0.1f;

        yield return null;
    }
    while(loadingUI.FillAmount<0.6 && loadingUI.FillAmount>0.3)
    {
        loadingtext.text = "球员正在送医..";

        loadingUI.targetFillAmount = asyncOperation.progress+0.1f;

        yield return null;
    }
    while(loadingUI.FillAmount<1 && loadingUI.FillAmount>0.6)
    {
        loadingtext.text = "场地清洁中...";

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
            asyncOperation.allowSceneActivation = true;
        }
    } 
}
