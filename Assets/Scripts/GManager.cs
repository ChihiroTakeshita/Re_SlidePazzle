using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager GameManager { get; private set; }

    [SerializeField] ScoreUI scoreUI;
    [SerializeField] SceneController sceneController;

    [SerializeField] public int defaultScore;
    [SerializeField] public float[] multiply;
    [SerializeField] public float maxTime;

    public bool freezing = false;
    public bool timeUp = false;

    private int m_score;

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

    public void AddScore(int score)
    {
        scoreUI.PrintScore(m_score, score);
        m_score += score;
        Debug.Log($"AddScore {score}");
        Debug.Log($"CurrentScore : {m_score}");
    }
}
