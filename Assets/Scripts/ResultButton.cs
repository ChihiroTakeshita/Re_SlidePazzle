using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButton : MonoBehaviour
{
    GManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GManager.GameManager;
    }

    public void OnClickToTitle()
    {
        Debug.Log("Back to Title");
    }

    public void OnClickRetry()
    {
        Debug.Log("Play Again");
    }
}
