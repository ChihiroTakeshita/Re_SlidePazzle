using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class TimeUI : MonoBehaviour
{
    [SerializeField] Slider slider;

    GManager gameManager;

    private float currentTime;

    // Start is called before the first frame update
    async void Start()
    {
        gameManager = GManager.GameManager;
        currentTime = gameManager.maxTime;
        while(currentTime >= 0)
        {
            await Timer();
        }
        Debug.Log("Time Up");
        gameManager.freezing = true;
    }

    public void SetSlider(float time)
    {
        slider.value = time / gameManager.maxTime;
    }

    private async UniTask Timer()
    {
        await UniTask.Delay(10);
        currentTime -= 0.01f;
        slider.value = currentTime / gameManager.maxTime;
    }
}
