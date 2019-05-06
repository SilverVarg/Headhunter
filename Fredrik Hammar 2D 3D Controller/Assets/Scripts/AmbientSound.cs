using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    private AudioSource[] sources;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        // ambient music source 
        sources[0].clip = clips[0];
        sources[0].loop = true;
        sources[0].Play();        
    }

    // Update is called once per frame
    void Update()
    {
        //owl source
        if (!sources[1].isPlaying)
        {
            float delay = Random.Range(10f, 120f);
            float pitch = Random.Range(0.7f, 1.0f);
            int clip = Random.Range(1, 3);

            sources[1].pitch = pitch;
            sources[1].clip = clips[clip];
            
            sources[1].PlayDelayed(delay); 
        }
        // wind source
        if (!sources[2].isPlaying)
        {
            float wind = Random.Range(0f, 1f);

            if(wind > 0.5)
            {
                sources[2].PlayOneShot(clips[3]);
            }
        }
    }
}
