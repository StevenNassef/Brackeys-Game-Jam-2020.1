using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class GeneralSounds : MonoBehaviour
{

    public GameObject sfx;
    public GameObject music;


    // Start is called before the first frame update
    void Start()
    {

    }

    void playSFX(AudioClip clip, bool loop) {
        sfx.GetComponent<AudioSource>().loop = loop;
        sfx.GetComponent<AudioSource>().clip = clip;
        sfx.GetComponent<AudioSource>().Play();
    }

    void playMusic(AudioClip clip, bool loop) {
        music.GetComponent<AudioSource>().loop = loop;
        music.GetComponent<AudioSource>().clip = clip;
        music.GetComponent<AudioSource>().Play();
    }
    
    void stopSFX(){
        sfx.GetComponent<AudioSource>().loop = false;
        sfx.GetComponent<AudioSource>().Stop();
    }
    
    void stopMusic(){
        music.GetComponent<AudioSource>().loop = false;
        music.GetComponent<AudioSource>().Stop();
    }

}
