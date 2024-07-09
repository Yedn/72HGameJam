using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class TeamAManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    public int PlayerNum = 5;//Ã¿±ß5¸öÇòÔ±

    struct playerlist
    {
        public bool ischose;
        public PlayerManager playercontrol;
    }


    private GameManager turnscript;

    private TeamAManager OtherTeamScript;

    //public PlayerManager[] Teamlist = new PlayerManager[2];
    void Start()
    {
        turnscript = GameObject.FindGameObjectWithTag("TurnSystem").GetComponent<GameManager>();
        if (this.tag == "TeamA")
        {
            OtherTeamScript = GameObject.FindGameObjectWithTag("TeamB").GetComponent<TeamAManager>();
        }
        else
        {
            OtherTeamScript = GameObject.FindGameObjectWithTag("TeamA").GetComponent<TeamAManager>();
        }

        playerlist[] playerlists = new playerlist[PlayerNum];

    }

    private void OnGUI()
    {
        if (turnscript.CurrentState == GameManager.GameState.Game)
        {
            if ((this.tag=="TeamA" && turnscript.teamlist[0]==true))
            {
                Debug.Log("TeamA's Turn");
            }
            else if ((this.tag=="TeamB" && turnscript.teamlist[1]==true))
            {
                Debug.Log("TeamB's Turn");
            }
            else
            {
                Debug.Log("ERROR");
            }
        }

        void YourUnit(int teamNum)
        {
            Debug.Log("WAIT FOR CONTROL");
        }

        IEnumerator OtherturnWait()
        {
            yield return new WaitForSeconds(1);
            turnscript.teamlist[0] = !turnscript.teamlist[0];
            turnscript.teamlist[1] = !turnscript.teamlist[1];
        }

    }

    // Update is called once per frame
    /***
    void Update()
    {
        
    }
    ***/
}
