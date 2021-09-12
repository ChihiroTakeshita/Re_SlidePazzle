using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTest : MonoBehaviour
{
    private bool isFadeIn = true;
    Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = Fade.fade;
    }

    public void OnClick()
    {
        if(isFadeIn)
        {
            fade.FadeIn();
            isFadeIn = false;
        }
        else
        {
            fade.FadeOut();
            isFadeIn = true;
        }
    }
}
