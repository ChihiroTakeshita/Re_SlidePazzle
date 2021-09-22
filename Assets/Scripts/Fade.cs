using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public static Fade fade { get; private set; }
    private Animator animator;

    void Awake()
    {
        if(fade == null)
        {
            DontDestroyOnLoad(this.gameObject);
            fade = this;
            animator = GetComponent<Animator>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void FadeIn()
    {
        animator.SetBool("isFadeIn", true);
    }

    public void FadeOut()
    {
        animator.SetBool("isFadeIn", false);
    }
}
