using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject logo;
    [SerializeField] GameObject reset;

    SoundEffectManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = SoundEffectManager.sfx;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            sfx.PlayClickSFX();
            title.SetActive(false);
            logo.SetActive(false);
            reset.SetActive(true);
        }
    }
}
