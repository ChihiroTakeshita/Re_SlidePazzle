using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    SceneController scene;

    public static Fade fade { get; private set; }
    [SerializeField] private Animator animator;

    private void Start()
    {
        scene = SceneController.scene;
        scene.fade = this;
        FadeIn();
    }

    public void FadeIn()
    {
        animator.SetBool("isFadeIn", true);
        Debug.Log("Fade In");
    }

    public void FadeOut()
    {
        animator.SetBool("isFadeIn", false);
        Debug.Log("Fade Out");
    }
}
