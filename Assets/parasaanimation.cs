using UnityEngine;

public class ParasaAnimation : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayOpenAnimation()
    {
        animator.Play("bag1");
    }

    public void PlayCloseAnimation()
    {
        animator.Play("bag2");
    }
}
