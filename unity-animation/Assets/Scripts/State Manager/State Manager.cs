using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject player;
    BaseState[] states;
    BaseState currentState;

    public enum States{
        IdleState = 0,
        RunState = 1,
        JumpState = 2,
        FallingState = 3,
        SplatState = 4,
        RecoverState = 5
    }

    // Start is called before the first frame update
    void Start()
    {
        states = new BaseState []{
            new IdleState(),
            new RunState(),
            new JumpState(),
            new FallingState(),
            new SplatState(),
            new RecoverState()
        };

        foreach(BaseState s in states){
            s.Init(this, player, player.GetComponent<PlayerAnimController>(), player.GetComponent<PlayerController>());
        }

        currentState = states[0];
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.responseUpdate();
    }

    public bool SwitchState(int stateIndex){
        if(stateIndex < 0 || stateIndex >= states.Length){
            return false;
        }

        currentState.ExitState();
        currentState = states[stateIndex];
        currentState.EnterState();
        return true;
    }

}