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
            if (inputManager.isRun) 
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
    }
}
