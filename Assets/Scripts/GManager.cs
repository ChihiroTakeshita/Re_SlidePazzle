using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager GameManager { get; private set; }

    public static int score;
    public static float time;
    public static int countR;
    public static int countG;
    public static int countB;
    public static int countY;

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

    public IEnumerator Wait(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }
}
