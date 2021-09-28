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
    }

    public void FadeOut()
    {
        animator.SetBool("isFadeIn", false);
    }
}
