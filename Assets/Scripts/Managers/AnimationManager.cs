using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private InputManager inputManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("PosX", inputManager.inputMovement.x);
        animator.SetFloat("PosZ", inputManager.inputMovement.z);

        if (inputManager.inputMovement.x != 0 || inputManager.inputMovement.z != 0)
        {
            if (inputManager.isRun && !inputManager.isCrouching) 
                animator.SetBool("IsRun", true);
            else 
                animator.SetBool("IsRun", false);

            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsRun", false);
        }

        if (inputManager.isDance)
            animator.SetBool("IsDance", true);
        else
            animator.SetBool("IsDance", false);

        if (inputManager.isCrouching && !inputManager.isJumping)
            animator.SetBool("IsCrouching", true);
        else
            animator.SetBool("IsCrouching", false);

        if (inputManager.isJumping && !inputManager.isCrouching)
            animator.SetBool("IsJump", true);
        else
            animator.SetBool("IsJump", false);

        if (inputManager.isFalling)
            animator.SetBool("IsFall", true);
        else
            animator.SetBool("IsFall", false);
    }
}
