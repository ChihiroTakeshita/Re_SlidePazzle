using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Fade fade;
    public static SceneController scene { get; private set; }

    private void Awake()
    {
        if(scene == null)
        {
            scene = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public async void SceneChange(string sceneName)
    {
        fade.FadeOut();
        await WaitChange(1.3f, sceneName);
    }

    private async UniTask WaitChange(float seconds, string sceneName)
    {
        await UniTask.Delay((int)(seconds * 1000));
        SceneManager.LoadScene(sceneName);
    }
}
