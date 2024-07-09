using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    

    public enum GameState
    {
        Menu,
        Game,
        Esc,
        Over
    }

    public GameState CurrentState = GameState.Game;//֮�����Ҫ�Ļ�Menu������û�г�ʼ����

    // Start is called before the first frame update
    [HideInInspector] static public bool[] teamlist = new bool[2]; //0����A,1����B
    //public TeamManager[] teammanager = new TeamManager[2];
    public GameObject[] TeamList;

    private TeamManager TeamAScript;
    private TeamManager TeamBScript;

    private BallCollide ballscript;

    void Start()
    {
        teamlist[0]= true;
        teamlist[1]= false;
        TeamAScript = TeamList[0].GetComponent<TeamManager>();
        TeamBScript = TeamList[1].GetComponent<TeamManager>();
        TeamAScript.isTurn = true;
        TeamBScript.isTurn = false;
    }

    private void OnGUI()
    {
        if (CurrentState == GameState.Menu)
        {
            Debug.Log("IN MENU");
        }
        else if (CurrentState == GameState.Over)
        {
            Debug.Log("HAS OVERED");
        }
        else if (CurrentState == GameState.Esc)
        {
            Debug.Log("ESC");
        }
    }

    private void GameStartButton(int teamNum)
    {
        if (GUI.Button(new Rect(50,30,100,20),"START"))
        {
            CurrentState = GameState.Game;
        }
    }

    private void GameRestartButton(int teamNum)
    {
        if (GUI.Button(new Rect(50, 30, 100, 20), "RESTART"))
        {
            teamlist[0] = true;
            teamlist[1]=false;
            CurrentState = GameState.Game;//֮�����TeamAB��Ա��ʼλ�õ��б�,transform��ȥ
        }
    }

    void checkBool()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("TeamA" + teamlist[0]);
            Debug.Log("TeamB" + teamlist[1]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        TeamAScript.isTurn = teamlist[0];
        TeamBScript.isTurn = teamlist[1];
        checkBool();
    }
}
