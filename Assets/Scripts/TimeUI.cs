using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class TimeUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] CountDown count;

    GManager gameManager;

    private float currentTime;
    public async void SetTimer()
    {
        gameManager = GManager.GameManager;
        currentTime = gameManager.maxTime;
        await Timer();
    }

    public void SetSlider(float time)
    {
        slider.value = time / gameManager.maxTime;
    }

    public async UniTask Timer()
    {
        float beforeUpdateTime = Time.time;
        while(currentTime >= 0)
        {
            float currentUpdateTime = Time.time;
            currentTime -= currentUpdateTime - beforeUpdateTime;
            slider.value = currentTime / gameManager.maxTime;
            beforeUpdateTime = currentUpdateTime;
            await UniTask.DelayFrame(1);
        }
        gameManager.timeUp = true;
        gameManager.freezing = true;
        count.TimeUp();
        await UniTask.Delay(1500);
        gameManager.LoadResult();
    }
}
