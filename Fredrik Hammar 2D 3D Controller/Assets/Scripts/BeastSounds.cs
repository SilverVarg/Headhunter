using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastSounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            float delay = Random.Range(1f, 5f);
            int clip = Random.Range(1, 3) - 1;
            float pitch = Random.Range(0.5f, 1.0f);

            source.clip = clips[clip];
            source.pitch = pitch;
          
            source.PlayDelayed(delay);
        }
    }
}
