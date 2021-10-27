using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class TimeUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] CountDown count;

    GManager gameManager;

    private float currentTime;
    public void SetTimer()
    {
        gameManager = GManager.GameManager;
        currentTime = gameManager.maxTime;
        SetSlider();
    }

    void SetSlider()
    {
        DOTween.To(() => slider.value, x => slider.value = x, 0, gameManager.maxTime).OnComplete(async () =>
        {
            gameManager.timeUp = true;
            gameManager.freezing = true;
            count.TimeUp();
            await UniTask.Delay(1500);
            gameManager.LoadResult();
        });
    }
}
