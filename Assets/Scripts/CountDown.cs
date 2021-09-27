using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI count;
    [SerializeField] Animator animator;

    SoundEffectManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = SoundEffectManager.sfx;
    }

    public async UniTask Count()
    {
        await UniTask.Delay(400);
        animator.SetBool("isStandby", false);
        for(int i = 3; i >= 0; i--)
        {
            if(i == 0)
            {
                count.text = "- Start -";
                sfx.PlayStartSFX();
            }
            else
            {
                count.text = "- " + i + " -";
                sfx.PlayCountDownSFX();
            }
            await UniTask.Delay(1000);
        }
        animator.SetBool("isStandby", true);
        count.text = "";
    }

    public void TimeUp()
    {
        count.text = "- Time Up -";
        sfx.PlayStartSFX();
        animator.SetBool("isTimeUp", true);
    }
}
