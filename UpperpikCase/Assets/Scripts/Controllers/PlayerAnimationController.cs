using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void RunPlayerMovementAnimation()
    {
        animator.SetBool("Run",true);
        animator.SetBool("Fly",false);
    }
    public void IdlePlayerMovementAnimation()
    {
        animator.SetBool("Run",false);
        animator.SetBool("Fly",false);
    }
    public void FlyingPlayerMovementAnimation()
    {
        animator.SetBool("Run",false);
        animator.SetBool("Fly",true);
    }
   
}
