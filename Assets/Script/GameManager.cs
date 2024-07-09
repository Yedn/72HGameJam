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

    public GameState CurrentState = GameState.Game;//之后测试要改回Menu，现在没有初始窗口

    // Start is called before the first frame update
    static public bool[] teamlist = new bool[2]; //0代表A,1代表B
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
            CurrentState = GameState.Game;//之后加上TeamAB成员初始位置的列表,transform回去
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
