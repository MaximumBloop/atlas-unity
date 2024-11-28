using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : BaseState
{
    public override void responseUpdate()
    {
        Debug.Log("Falling");

        // Transition to 'Splat' if we hit the ground
        if (playerController.groundedPlayer)
        {
            StateManagerInstance.SwitchState((int)StateManager.States.SplatState);
        }
    }

    public override void EnterState(){
        Debug.Log("Start Fall");

        // Start animating
        AnimatorInstance.AnimateFalling();
    }

    public override void ExitState(){
        Debug.Log("Exit Fall");
    }
}
