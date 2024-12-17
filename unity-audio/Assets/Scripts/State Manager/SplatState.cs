using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatState : BaseState
{
    AudioSource landingAudioSource;
    public override void responseUpdate()
    {
        Debug.Log("SPLATTED");

        // Get up from ground after a bit of time
        StateManagerInstance.SwitchState((int)StateManager.States.RecoverState);
    }

    public override void EnterState(){
        Debug.Log("Start Splat");

        // Start animating
        AnimatorInstance.AnimateSplat();
        landingAudioSource = fetchAudioSourceComponent("footsteps_landing_grass");
        landingAudioSource?.Play();
    }

    public override void ExitState(){
        Debug.Log("Get up, man! (Exit Splat)");
    }
}
