using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            if(Input.GetKey(KeyCode.LeftShift) == false && Input.GetKey(KeyCode.RightShift) == false)
            {
                animator.SetBool("NothingPressed", false);
                animator.SetBool("MoveAndShiftPressed", false);
                animator.SetBool("MoveAndShiftNotPressed", true);
            }
            else if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                animator.SetBool("NothingPressed", false);
                animator.SetBool("MoveAndShiftPressed", true);
                animator.SetBool("MoveAndShiftNotPressed", false);
            }
        }
        else
        {
            animator.SetBool("NothingPressed", true);
            animator.SetBool("MoveAndShiftPressed", false);
            animator.SetBool("MoveAndShiftNotPressed", false);
        }
    }
    
}
