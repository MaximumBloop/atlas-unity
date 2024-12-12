using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public override void responseUpdate()
    {
        Debug.Log("Run");

        // Transition to 'Idle' if we aren't moving/jumping
        if (playerController.groundedPlayer && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            StateManagerInstance.SwitchState((int)StateManager.States.IdleState);
        }

        // Transition to 'Jump' if we are jumping
        if (!playerController.groundedPlayer || playerController.jumpHeld)
        {
            StateManagerInstance.SwitchState((int)StateManager.States.JumpState);
        }
    }

    public override void EnterState(){
        Debug.Log("Start Run");

        // Start animating
        AnimatorInstance.AnimateRun();
    }

    public override void ExitState(){
        Debug.Log("Exit Run");
    }
}
