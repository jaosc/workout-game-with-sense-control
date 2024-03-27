using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource mAudioSource;
    public AudioClip gameOverClip;
    void Start()
    {
        
        mAudioSource = GetComponent<AudioSource>();
        if(mAudioSource == null){
            throw new System.Exception("No AudioSource on AudioController");
        }

        PlayerStats.OnStaminaChange += ChangeAudioMonitor;
        
    }

    void OnDisable(){
        PlayerStats.OnStaminaChange -= ChangeAudioMonitor;
    }

    void ChangeAudioMonitor(int value){

        if(value <= 0){
            mAudioSource.Stop();
            mAudioSource.PlayOneShot(gameOverClip);
        }

    }
}
