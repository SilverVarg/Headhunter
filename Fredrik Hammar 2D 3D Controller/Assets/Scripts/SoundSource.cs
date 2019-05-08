using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    public GameObject Item;
    public AudioClip audioClip;
    private Songbird songBird;
    private bool play = true;
    private bool added = false;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        songBird = Item.GetComponent<Songbird>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (play && !audioSource.isPlaying)
        {
            if (audioClip != null)
            {
                StartCoroutine(PlayMusic());
            }
        }
        
    }
    IEnumerator PlayMusic()
    {
        play = false;
        audioSource.Play();
        float seconds = audioSource.clip.length;
        yield return new WaitForSeconds(seconds);
        play = true;
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Songbird" && added == false)
        {
            if (audioClip != null)
            {
                
                songBird.Add(songBird.audioClips, audioClip);
                added = true;
            }
        }
     }
}
