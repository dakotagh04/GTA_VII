using JetBrains.Annotations;
using UnityEngine;

public class ForceLevelPosition : MonoBehaviour
{
    public bool activated = false;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        ForceAnimation();
    }

    void ForceAnimation()
    {
        if (activated == true)
        {
            animator.SetBool("isActive", true);
            animator.Play("ToActive", 0, 1f);
        }
        else
        {
            animator.SetBool("isActive", false);
            animator.Play("ToUnactive", 0, 1f);
        }
    }
}
