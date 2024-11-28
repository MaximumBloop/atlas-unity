using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    public override void responseUpdate()
    {
        Debug.Log("Jump");
        
        // Transition to 'Falling' if:
        // ) We are going faster downward than a pre-defined threshold
        if (playerController.playerVelocity.y <= PlayerController.TerminalVelocity)
        {
            StateManagerInstance.SwitchState((int)StateManager.States.FallingState);
        }

        // 'Jump' shouldn't be played if the player is grounded
        if (playerController.groundedPlayer)
        {
            // Transition to 'Run' if:
            // ) we are not airborne, and
            // ) we are receiving player input
            // --------------------------------
            // Transition to 'Idle' if:
            // ) we are not airborne, and
            // ) we are not receiving player input
            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                StateManagerInstance.SwitchState((int)StateManager.States.RunState);
            } else
            {
                StateManagerInstance.SwitchState((int)StateManager.States.IdleState);
            }
        }
    }

    public override void EnterState(){
        Debug.Log("Start Jump");

        // Start animating
        AnimatorInstance.AnimateJump();
    }

    public override void ExitState(){
        Debug.Log("Exit Jump");
    }
}
