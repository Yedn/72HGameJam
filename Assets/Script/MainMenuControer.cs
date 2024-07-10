using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    public GameObject loadingPanel;
    public void StartGame()
    {
        gameObject.SetActive(false);

        loadingPanel.SetActive(true);


    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void retrunToTitle()
    {
        gameObject.SetActive(true);
        loadingPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
