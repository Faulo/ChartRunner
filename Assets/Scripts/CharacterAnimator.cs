using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator animator;
    public AvatarController ac;

    void Start() {
        //GetComponent<Animator>();
        //GetComponent<AvatarController>();
    }
    void Update() {

        //TODOs Falling & Run Backwards (umdrehen?)
        
        animator.ResetTrigger("TakeOff");

        if (ac.intendsJumpStart) {
            animator.SetTrigger("TakeOff");
            animator.SetBool("IsJumping", true);
        }

        //NEED_ ac.intended Falling
        //if (ac.falling) {
        //    animator.SetBool("IsJumping", false);
       // }


        if (ac.intendedMovement == 0f) {
            animator.SetBool("IsRunning", false);
        } else {
            animator.SetBool("IsRunning", true);
        }
       
    }
}
