using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{
    GManager gameManager;
    SoundEffectManager sfx;

    [SerializeField] GameObject title;
    [SerializeField] GameObject demo;
    [SerializeField] GameObject logo;

    [SerializeField] GameObject reset;
    [SerializeField] GameObject[] resetBottun;
    [SerializeField] GameObject afterReset;
    [SerializeField] TextMeshProUGUI text;

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
        logo.SetActive(false);
        demo.SetActive(true);
        Debug.Log("Open Menu");
    }

    public void OnClickCloseMenu()
    {
        demo.SetActive(false);
        title.SetActive(true);
        logo.SetActive(true);
        sfx.PlayClickSFX();
        Debug.Log("Close Menu");
    }

    public void OnClickResetYes()
    {
        sfx.PlayClickSFX();
        PlayerPrefs.SetInt("highScore", 0);
        foreach (var item in resetBottun)
        {
            item.SetActive(false);
        }
        afterReset.SetActive(true);
        text.text = "リセットしました";
    }

    public void OnClickResetNo()
    {
        sfx.PlayClickSFX();
        reset.SetActive(false);
        title.SetActive(true);
        logo.SetActive(true);
    }
}
