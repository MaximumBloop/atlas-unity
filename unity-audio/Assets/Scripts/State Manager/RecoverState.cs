using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverState : BaseState
{
    public override void responseUpdate()
    {
        Debug.Log("Recovering");

        // Transition to 'Idle'
        StateManagerInstance.SwitchState((int)StateManager.States.IdleState);
        
    }

    public override void EnterState(){
        Debug.Log("Start Recover");

        // Start animating
        AnimatorInstance.AnimateSplat();
    }

    public override void ExitState(){
        Debug.Log("We got up! (Exit Recover)");
    }
}
