using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager sfx { get; private set; }

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        if(sfx == null)
        {
            sfx = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClickSFX()
    {
        audioSource.PlayOneShot(clips[0]);
    }

    public void PlayCountDownSFX()
    {
        audioSource.PlayOneShot(clips[1]);
    }

    public void PlayStartSFX()
    {
        audioSource.PlayOneShot(clips[2]);
    }

    public void PlayMoveBlockSFX()
    {
        audioSource.PlayOneShot(clips[3]);
    }

    public void PlayDeleteBlockSFX()
    {
        audioSource.PlayOneShot(clips[4]);
    }
}
