using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigilConnectSFX : MonoBehaviour
{
    public static SigilConnectSFX instance{private set; get;}
    public AudioClip audioClip;
    public float pitchIncrease;

    private float defaultPitch;
    private AudioSource audioSource;

    void Awake(){
        if(!instance) instance = this;
        else Destroy(this);
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
        defaultPitch = audioSource.pitch - pitchIncrease;
        audioSource.pitch = defaultPitch;
        audioSource.clip = audioClip;
    }

    public void playSFX(){
        audioSource.pitch += pitchIncrease;
        audioSource.Play();
    }

    public void resetPitch(){
        audioSource.pitch = defaultPitch;
    }
}
