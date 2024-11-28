using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    #region Attributes

    Animator animator;

    private const string IDLE_ANIMATION_BOOL = "idle";
    private const string RUN_ANIMATION_BOOL = "run";
    private const string JUMP_ANIMATION_BOOL = "jump";
    private const string FALLING_ANIMATION_BOOL = "falling";
    private const string SPLAT_ANIMATION_BOOL = "splat";
    private const string RECOVER_ANIMATION_BOOL = "recover";

    #endregion

    #region Animate Functinos

    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }

    public void AnimateRun()
    {
        Animate(RUN_ANIMATION_BOOL);
    }

    public void AnimateJump()
    {
        Animate(JUMP_ANIMATION_BOOL);
    }

    public void AnimateFalling()
    {
        Animate(FALLING_ANIMATION_BOOL);
    }

    public void AnimateSplat()
    {
        Animate(SPLAT_ANIMATION_BOOL);
    }

    public void AnimateRecover()
    {
        Animate(RECOVER_ANIMATION_BOOL);
    }

    # endregion

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator, boolName);

        animator.SetBool(boolName, true);
    }

    private void DisableOtherAnimations(Animator animator, string animation)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
}
