using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Fade fade;
    public static SceneController scene { get; private set; }

    private void Awake()
    {
        if(scene == null)
        {
            scene = this;
            DontDestroyOnLoad(this.gameObject);
            fade = Fade.fade;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SceneChange(string sceneName)
    {
        fade.FadeOut();
        StartCoroutine(Wait(1.3f, () => {
            SceneManager.LoadScene(sceneName);
        }));
        fade.FadeIn();
    }

    private IEnumerator Wait(float second, Action action)
    {
        yield return new WaitForSeconds(second);
        action();
    }
}
