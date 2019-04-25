using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip;
    private float range;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        range = Random.Range(0.5f, 1.5f);

        if (!source.isPlaying)
        {
            source.pitch = range;
            source.PlayOneShot(clip);
        }
        
    }
}
