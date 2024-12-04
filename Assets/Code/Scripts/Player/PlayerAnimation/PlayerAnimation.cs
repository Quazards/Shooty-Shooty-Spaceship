using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Vector2 input;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void GetMovementInput(Vector2 movementInput)
    {
        input = movementInput;
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", input.x);
        if(input.x == 0)
        {
            animator.SetTrigger("StopTurning");
        }
    }
}
