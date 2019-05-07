using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    private void Update()
    {
        mixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("Volume"));
    }

    public void SetLevel(float SliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(SliderValue) * 20);
        PlayerPrefs.SetFloat("Volume", Mathf.Log10(SliderValue) * 20);
    }    
}
