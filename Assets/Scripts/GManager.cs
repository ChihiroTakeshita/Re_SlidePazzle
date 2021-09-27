using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager GameManager { get; private set; }

    public ScoreUI scoreUI;
    SceneController sceneController;

    [SerializeField] public int defaultScore;
    [SerializeField] public float[] multiply;
    [SerializeField] public float maxTime;

    public bool freezing = true;
    public bool timeUp = false;

    public int m_score { get; private set; }

    private void Awake()
    {
        if(GameManager == null)
        {
            GameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        sceneController = SceneController.scene;
        if(!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
            PlayerPrefs.SetInt("isFirst", 0);
        }
    }

    public void AddScore(int score)
    {
        scoreUI.PrintScore(m_score, score);
        m_score += score;
        Debug.Log($"AddScore {score}");
        Debug.Log($"CurrentScore : {m_score}");
    }

    public void LoadTitle()
    {
        Debug.Log("Load Title");
        sceneController.SceneChange("Title");
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
        m_score = 0;
        timeUp = false;
        sceneController.SceneChange("Game");
    }

    public void LoadResult()
    {
        Debug.Log("Load Result");
        sceneController.SceneChange("Result");
    }
}
