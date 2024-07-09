using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Core;
    public GameObject Tracer;
    private ClickDetector ChosenState;

    private bool isChosen = false;
    private bool isTurn = false;
    // Start is called before the first frame update
    void Start()
    {
        ChosenState = Core.GetComponent<ClickDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurn)
        {
            ChosenState.SetTurn(isTurn);
            isChosen = ChosenState.getChosenState();
            Tracer.GetComponent<TracerManager>().SetChosen(isChosen);

            //if (Input.GetKeyDown(KeyCode.E) && isChosen) Debug.Log("from PlayyerCon");
            //else Debug.Log("from PlayyerCon turfal");
            if (Input.GetKeyDown(KeyCode.Mouse1)) UnChoseState();
        }
        else
        {
            UnChoseState();
            ChosenState.SetTurn(isTurn);
            Tracer.GetComponent<TracerManager>().SetChosen(isTurn);
        }
    }

    public bool getChosenState()
    {
        return this.isChosen;
    }

    public void UnChoseState()
    {
        this.isChosen = false;
        ChosenState.UnChosen();
    }

    public void SetTurn(bool st)
    {
        isTurn = st;
    }

}
