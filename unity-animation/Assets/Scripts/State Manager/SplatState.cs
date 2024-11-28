using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatState : BaseState
{
    public override void responseUpdate()
    {
        Debug.Log("SPLATTED");

        // Transition to 'Splat' if we hit the ground
        
    }

    public override void EnterState(){
        Debug.Log("Start Splat");

        // Start animating
        AnimatorInstance.AnimateSplat();
    }

    public override void ExitState(){
        Debug.Log("Get up, man! (Exit Splat)");
    }
}
