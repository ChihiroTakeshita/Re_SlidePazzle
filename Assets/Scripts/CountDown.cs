using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI count;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
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
            }
            else
            {
                count.text = "- " + i + " -";
            }
            await UniTask.Delay(1000);
        }
        animator.SetBool("isStandby", true);
        count.text = "";
    }

    public void TimeUp()
    {
        count.text = "- Time Up -";
        animator.SetBool("isTimeUp", true);
    }
}
