using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public AudioSource[] soundEffects;

    public AudioSource menuMusic, backgroundMusic;


    public static AudioManager instance;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update

    private void Update()
    {
        
    }

    public void PlaySFX(int soundToPlay)
    {
        //soundEffects[soundToPlay].gameObject.SetActive(true);
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].Play();

    }
    public void PlayMenuMusic()
    {
        backgroundMusic.Stop();

        menuMusic.Play();

    }

    public void ChangeMusicPitch(float  pitch)
    {
        backgroundMusic.pitch = pitch;
    }
   
    public void PlayBackgrounMusic()
    {
     
        menuMusic.Stop();
        backgroundMusic.Play();
    }


  

}
