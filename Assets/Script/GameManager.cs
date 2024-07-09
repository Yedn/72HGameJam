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
    static public bool[] teamlist = new bool[2]; //0����A,1����B
    public TeamAManager[] teammanager = new TeamAManager[2];

    private TeamAManager TeamAScript;
    private TeamAManager TeamBScript;

    private BallCollide ballscript;

    void Start()
    {
        teamlist[0]= true;
        teamlist[1]= false;
        TeamAScript = GameObject.FindGameObjectWithTag("TeamA").GetComponent<TeamAManager>();
        TeamBScript = GameObject.FindGameObjectWithTag("TeamB").GetComponent<TeamAManager>();
        
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
    // Update is called once per frame
    void Update()
    {
    }
}
