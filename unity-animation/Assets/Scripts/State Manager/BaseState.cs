using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    protected StateManager StateManagerInstance;
    protected GameObject playerInstance;
    protected PlayerAnimController AnimatorInstance;
    protected PlayerController playerController;
    public virtual void Init(
            StateManager sm, 
            GameObject p, 
            PlayerAnimController a,
            PlayerController pc){
        StateManagerInstance = sm;
        playerInstance = p;
        AnimatorInstance = a;
        playerController = pc;
    }
    public abstract void responseUpdate();
    public abstract void EnterState();
    public abstract void ExitState();
}
