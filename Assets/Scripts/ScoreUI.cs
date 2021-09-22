using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

public class ScoreUI : MonoBehaviour
{
    GManager gameManager;

    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GManager.GameManager;
    }

    public async void PrintScore(int currentScore, int addScore)
    {
        int printScore = currentScore;
        for(int i = 0; i < addScore; i++)
        {
            printScore++;
            if (printScore < 10)
            {
                scoreText.text = $"0000{printScore}";
            }
            else if (printScore < 100)
            {
                scoreText.text = $"000{printScore}";
            }
            else if (printScore < 1000)
            {
                scoreText.text = $"00{printScore}";
            }
            else if (printScore < 10000)
            {
                scoreText.text = $"0{printScore}";
            }
            else
            {
                scoreText.text = $"{printScore}";
            }
            await AddCurrent();
        }
    }

    private async UniTask AddCurrent()
    {
        await UniTask.Delay(1);
    }
}
