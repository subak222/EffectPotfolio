using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isReady", false);
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            animator.SetBool("isReady", true);
        }
        else if (Input.GetKeyUp("e"))
        {
            animator.SetBool("isReady", false);
        }
    }
}
