using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScore;

    private void OnEnable()
    {
        if(PlayerPrefs.HasKey("highScore"))
        {
            int score = PlayerPrefs.GetInt("highScore");
            if(score < 10)
            {
                highScore.text = "High Score  0000" + score;
            }
            else if (score < 100)
            {
                highScore.text = "High Score  000" + score;
            }
            else if (score < 1000)
            {
                highScore.text = "High Score  00" + score;
            }
            else if (score < 10000)
            {
                highScore.text = "High Score  0" + score;
            }
            else
            {
                highScore.text = "High Score  " + score;
            }
        }
        else
        {
            highScore.text = "High Score  00000";
        }
    }
}
