using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

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

    public async void SceneChange(string sceneName)
    {
        fade.FadeOut();
        /*
        StartCoroutine(Wait(1.3f, () => {
            SceneManager.LoadScene(sceneName);
        }));
        */
        await WaitChange(1.3f, sceneName);
        fade.FadeIn();
    }

    /*
    private IEnumerator Wait(float second, Action action)
    {
        yield return new WaitForSeconds(second);
        action();
    }
    */

    private async UniTask WaitChange(float seconds, string sceneName)
    {
        await UniTask.Delay((int)(seconds * 1000));
        SceneManager.LoadScene(sceneName);
    }
}
