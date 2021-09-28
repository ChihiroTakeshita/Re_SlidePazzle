using UnityEngine;

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
        }
        else if(block == "Blue")
        {
            color.color = colors[1];
        }
        else if(block == "Green")
        {
            color.color = colors[2];
        }
        else if(block == "Yerrow")
        {
            color.color = colors[3];
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
        Destroy(this.gameObject);
    }
}
