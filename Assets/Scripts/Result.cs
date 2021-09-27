using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] Animator highScore;
    GManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GManager.GameManager;
        PrintResult(gameManager.m_score);
        if(PlayerPrefs.GetInt("highScore") < gameManager.m_score)
        {
            PlayerPrefs.SetInt("highScore", gameManager.m_score);
            highScoreText.text = "High Score  " + gameManager.m_score.ToString();
            highScore.SetBool("isHighScore", true);
        }
        else
        {
            highScoreText.text = "High Score  " + PlayerPrefs.GetInt("highScore").ToString();
            highScore.SetBool("isHighScore", false);
        }
    }

    public void PrintResult(int result)
    {
        scoreText.text = result.ToString();
    }
}
