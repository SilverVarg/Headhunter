﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongbirdAttached : MonoBehaviour
{



    public AudioClip[] audioClips;

    [HideInInspector] public bool Playable = true;

    private int musicNumber = 0;
    private bool playNextMusic = true;
    private bool PlayAllSongs = false;
    public int goal;
    private bool done = true;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {
  
        if (audioClips.Length != 0)
        {
            Debug.Log("working");
        }
        if (Input.GetKeyUp(KeyCode.Q) && Playable == true && audioClips != null && PlayAllSongs == false)
        {

            PlayAllSongs = true;


        }
        if (PlayAllSongs)
        {
            if (playNextMusic)
            {

               StartCoroutine(PlayTheNextMusic());

            }
        }
    }
    public bool donewithLevel()
    {
        done = false;
        if (audioClips.Length == goal)
        {
            done = true;
        }
        return done;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Goal" && done == true)
        {
            Debug.Log("goal");
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator PlayTheNextMusic()
    {
        playNextMusic = false;
        GetComponent<AudioSource>().clip = audioClips[musicNumber];
        GetComponent<AudioSource>().Play();
        float seconds = GetComponent<AudioSource>().clip.length;
        yield return new WaitForSeconds(seconds);
        playNextMusic = true;
        ++musicNumber;
        int lenght = audioClips.Length;
        if (musicNumber == lenght)
        {
            musicNumber = 0;
            PlayAllSongs = false;
        }


    }
    public void Add(AudioClip[] array, AudioClip newValue)
    {
        int newLength = array.Length + 1;

        AudioClip[] result = new AudioClip[newLength];

        for (int i = 0; i < array.Length; i++)
            result[i] = array[i];

        result[newLength - 1] = newValue;

        for (int i = 0; i < result.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (string.Compare(result[j].name, result[j - 1].name) < 0)
                {
                    AudioClip temp = result[j - 1];
                    result[j - 1] = result[j];
                    result[j] = temp;
                }
            }
        }

        audioClips = result;
    }




}
