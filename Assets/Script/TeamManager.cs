using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public GameObject[] PlayerList;
    //[HideInInspector] public bool[] ChosePlayer = new bool[5];

    private bool isTurn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isTurn = !isTurn;
            foreach (GameObject player in PlayerList)
            {
                player.GetComponent<PlayerController>().SetTurn(isTurn);
            }
        }

    }
}
