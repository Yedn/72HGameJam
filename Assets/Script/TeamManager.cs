using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public GameObject[] PlayerList;
    //[HideInInspector] public bool[] ChosePlayer = new bool[5];
    
    public bool isTurn = false;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject player in PlayerList)
        {
            player.GetComponent<PlayerController>().SetTurn(isTurn);
        }
    }

    private int playerInGame;

    public bool NotSurvive()
    {
        playerInGame = 0;
        foreach(GameObject player in PlayerList)
        {
            if (player.activeSelf)
            {
                playerInGame++;
            }
        }
        return (playerInGame == 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    isTurn = !isTurn;

        foreach (GameObject player in PlayerList)
        {
            player.GetComponent<PlayerController>().SetTurn(isTurn);
        }
        //}
        CheckMulti();

    }

    void CheckMulti()
    {
        int count = 0;
        bool muti = false;
        foreach (GameObject player in PlayerList)
        {
           if( player.GetComponent<PlayerController>().getChosenState())
            {
                count++;
                if (count > 1)
                {
                    muti = true;
                    break;
                }
            }
        }
        if (muti)
        {

            foreach (GameObject player in PlayerList)
            {
                player.GetComponent<PlayerController>().UnChoseState();
            }
        }
    }

}
