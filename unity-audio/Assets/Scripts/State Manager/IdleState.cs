using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void responseUpdate()
    {
        Debug.Log("Idling...");

        // Transition to 'Run' if:
        // ) we are on the ground, and
        // ) we are receiving input
        if (playerController.groundedPlayer && (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0))
        {
            StateManagerInstance.SwitchState((int)StateManager.States.RunState);
        }

        // Transition to 'Jump' if:
        // ) we are NOT on the ground, and
        // ) we are moving upward
        if (!playerController.groundedPlayer && playerController.playerVelocity.y > 0)
        {
            StateManagerInstance.SwitchState((int)StateManager.States.JumpState);
        }
    }

    public override void EnterState(){
        Debug.Log("Start Idle");

        //Trigger animation queues
        AnimatorInstance.AnimateIdle();
        //Trigger audio

        //Ensure everything is set up for update loop
    }

    public override void ExitState(){
        Debug.Log("Exit Idle");

        // Stop animation
    }
}
