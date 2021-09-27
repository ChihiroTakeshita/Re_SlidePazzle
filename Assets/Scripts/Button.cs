using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    GManager gameManager;
    SoundEffectManager sfx;

    [SerializeField] GameObject title;
    [SerializeField] GameObject demo;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GManager.GameManager;
        sfx = SoundEffectManager.sfx;
    }

    public void OnClickToTitle()
    {
        sfx.PlayClickSFX();
        Debug.Log("Back to Title");
        gameManager.LoadTitle();
    }

    public void OnClickStartGame()
    {
        sfx.PlayClickSFX();
        Debug.Log("Let's Play");
        gameManager.LoadGame();
    }

    public void OnClickMenu()
    {
        sfx.PlayClickSFX();
        title.SetActive(false);
        demo.SetActive(true);
        Debug.Log("Open Menu");
    }

    public void OnClickCloseMenu()
    {
        demo.SetActive(false);
        title.SetActive(true);
        sfx.PlayClickSFX();
        Debug.Log("Close Menu");
    }
}
