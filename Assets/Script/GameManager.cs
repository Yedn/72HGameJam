using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public int winscare = 5;
    public enum GameState
    {
        Menu,
        Game,
        Esc,
        Over
    }

    static public bool canAction = true;

    public GameState CurrentState = GameState.Game;//之后测试要改回Menu，现在没有初始窗口

    // Start is called before the first frame update
    [HideInInspector] static public bool[] teamlist = new bool[2]; //0代表A,1代表B
    //public TeamManager[] teammanager = new TeamManager[2];
    public GameObject[] TeamList;

    

    private TeamManager TeamAScript;
    private TeamManager TeamBScript;

    public Vector2[] Astartpos;
    public Vector2[] Bstartpos;

    private BallCollide ballscript;

    void Start()
    {
        teamlist[0]= true;
        teamlist[1]= false;
        TeamAScript = TeamList[0].GetComponent<TeamManager>();
        TeamBScript = TeamList[1].GetComponent<TeamManager>();
        TeamAScript.isTurn = true;
        TeamBScript.isTurn = false;
        ballscript = transform.Find("Ball/Circle").GetComponent<BallCollide>();
        Astartpos = new Vector2[TeamAScript.PlayerList.Length];
        Bstartpos = new Vector2[TeamAScript.PlayerList.Length];

        for (int i=0;i<TeamAScript.PlayerList.Length;i++)
        {
            Astartpos[i] = new Vector2(TeamAScript.PlayerList[i].transform.position.x, TeamAScript.PlayerList[i].transform.position.y);
            Bstartpos[i] = new Vector2(TeamBScript.PlayerList[i].transform.position.x, TeamBScript.PlayerList[i].transform.position.y);
        }
    }

    private bool isOver = false;

    private void OnGUI()
    {
        if (CurrentState == GameState.Menu)
        {
            Debug.Log("IN MENU");
        }
        else if (CurrentState == GameState.Over)
        {
            isOver = true;
            TeamAScript.ResetPlayerPos();
            TeamBScript.ResetPlayerPos();
            ballscript.ResetBallPos();
            BallCollide.Ascare = BallCollide.Bscare = 0;
            CurrentState = GameState.Game;
            //.localPosition = Vector3.MoveTowards(TeamAScript.PlayerList[i].transform.position, Astartpos[i],999);
            //Debug.Log("HAS OVERED");
            //Time.timeScale = 0f;
        }
        else if (CurrentState == GameState.Esc)
        {
            Debug.Log("ESC");
        }
    }

    private void overgame()
    {
        if (CurrentState == GameState.Game)
        {
            if (BallCollide.Ascare == 5 || BallCollide.Bscare == 5)
            {

                if (BallCollide.Ascare > BallCollide.Bscare)
                {
                    Debug.Log("A win");
                }
                else
                {
                    Debug.Log("B win");
                }
                CurrentState = GameState.Over;
                BallCollide.Ascare = BallCollide.Bscare = 0;
            }

            if (TeamList[0].GetComponent<TeamManager>().NotSurvive())
            {
                Debug.Log("B win");
                CurrentState = GameState.Over;
                BallCollide.Ascare = BallCollide.Bscare = 0;
            }
            else if (TeamList[1].GetComponent<TeamManager>().NotSurvive())
            {
                Debug.Log("A win");
                CurrentState = GameState.Over;
                BallCollide.Ascare = BallCollide.Bscare = 0;
            }
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
        overgame();
        //if(isOver)
        //{
        //    for (int i = 0; i < TeamAScript.PlayerList.Length; i++)
        //    {
        //        TeamAScript.PlayerList[i].transform.position = new Vector2(Astartpos[i].x, Astartpos[i].y);
        //        TeamBScript.PlayerList[i].transform.position = new Vector2(Bstartpos[i].x, Bstartpos[i].y);
        //        Debug.Log(TeamBScript.PlayerList[i].transform.position.ToString() + "Orijin");
        //        Debug.Log(Bstartpos[i].ToString() + "set");
        //    }
        //    //isOver = false;
        //}
    }
}
