﻿using System;
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

    private int m_score;
    private float m_time;
    private int m_countR;
    private int m_countG;
    private int m_countB;
    private int m_countY;

    private void Awake()
    {
        if(GameManager == null)
        {
            GameManager = this;
            DontDestroyOnLoad(this.gameObject);
            AddScore(0);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddScore(int score)
    {
        m_score += score;
        scoreUI.ShowScore(m_score);
        Debug.Log($"AddScore {score}");
    }
}
