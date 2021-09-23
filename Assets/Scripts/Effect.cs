using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Effect : MonoBehaviour
{
    [SerializeField] Color32[] colors;
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
            color.color = colors[0];
            Debug.Log("Change to Red");
        }
        else if(block == "Blue")
        {
            color.color = colors[1];
            Debug.Log("Change to Blue");
        }
        else if(block == "Green")
        {
            color.color = colors[2];
            Debug.Log("Change to Green");
        }
        else if(block == "Yerrow")
        {
            color.color = colors[3];
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

    public void OnParticleSystemStopped()
    {
        Debug.Log("ParticleSystemStopped");
        Destroy(this.gameObject);
    }
}
