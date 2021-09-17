using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    GManager gameManager;

    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GManager.GameManager;
    }

    public void ShowScore(int currentScore)
    {
        if(currentScore < 10)
        {
            scoreText.text = $"0000{currentScore}";
        }
        else if (currentScore < 100)
        {
            scoreText.text = $"000{currentScore}";
        }
        else if (currentScore < 1000)
        {
            scoreText.text = $"00{currentScore}";
        }
        else if (currentScore < 10000)
        {
            scoreText.text = $"0{currentScore}";
        }
        else
        {
            scoreText.text = currentScore.ToString();
        }
    }
}
