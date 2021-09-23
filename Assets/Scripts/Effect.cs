using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    ParticleSystem.MinMaxGradient color;

    // Start is called before the first frame update
    void Start()
    {
        color = new ParticleSystem.MinMaxGradient();
        color.mode = ParticleSystemGradientMode.Color;
    }

    public void PlayEffect(string block)
    {
        if(block == "Red")
        {
            color.color = new Color32(242, 77, 114, 255);
            Debug.Log("Change to Red");
        }
        else if(block == "Blue")
        {
            color.color = new Color32(8, 200, 232, 255);
            Debug.Log("Change to Blue");
        }
        else if(block == "Green")
        {
            color.color = new Color32(204, 255, 29, 255);
            Debug.Log("Change to Green");
        }
        else if(block == "Yerrow")
        {
            color.color = new Color32(253, 245, 8, 255);
            Debug.Log("Change to Yerrow");
        }
        else
        {
            Debug.LogError("ERROR!");
        }
        var main = particle.main;
        main.startColor = color;
        particle.Play();
    }
    /*
    private void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }*/
}
