using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class GeneralSounds : MonoBehaviour
{

    public GameObject sfx;
    public GameObject music;
    public GameObject master;
    public GameObject background;
    public GameObject effect;

    public AudioClip musicTrack;

    public AudioClip cubeSound;
    public AudioClip tileActivateSound;
    public AudioClip portalSound;
    public AudioClip deathCharacterSound;
    public AudioClip gruntCharacterSound;
    public AudioClip colorSound;
    public AudioClip zombieSound;


    // Start is called before the first frame update
    void Start()
    {

    }

    [ButtonMethod]
    public void playZombieSound() {
        playBackground(zombieSound, true);
    }

    [ButtonMethod]
    public void playDeathSound() {
        playBackground(deathCharacterSound, false);
    }

    [ButtonMethod]
    public void playGruntCharacterSound() {
        playEffect(gruntCharacterSound, false);
    }

    [ButtonMethod]
    public void playColorSound() {
        playEffect(colorSound, false);
    }

    [ButtonMethod]
    public void playCubeSound() {
        playEffect(cubeSound, false);
    }

    [ButtonMethod]
    public void playTileActivateSound() {
        playEffect(tileActivateSound, false);
    }

    [ButtonMethod]
    public void playPortalSound() {
        playEffect(portalSound, false);
    }

    [ButtonMethod]
    public void playMusic() {
        playMusic(musicTrack, true);
    }

    public void playEffect(AudioClip clip, bool loop) {
        effect.GetComponent<AudioSource>().loop = loop;
        effect.GetComponent<AudioSource>().clip = clip;
        effect.GetComponent<AudioSource>().Play();
    }

    public void playBackground(AudioClip clip, bool loop) {
        background.GetComponent<AudioSource>().loop = loop;
        background.GetComponent<AudioSource>().clip = clip;
        background.GetComponent<AudioSource>().Play();
    }

    public void playSFX(AudioClip clip, bool loop) {
        sfx.GetComponent<AudioSource>().loop = loop;
        sfx.GetComponent<AudioSource>().clip = clip;
        sfx.GetComponent<AudioSource>().Play();
    }

    public void playMusic(AudioClip clip, bool loop) {
        music.GetComponent<AudioSource>().loop = loop;
        music.GetComponent<AudioSource>().clip = clip;
        music.GetComponent<AudioSource>().Play();
    }

    public void playMaster(AudioClip clip, bool loop) {
        master.GetComponent<AudioSource>().loop = loop;
        master.GetComponent<AudioSource>().clip = clip;
        master.GetComponent<AudioSource>().Play();
    }
    

    [ButtonMethod]
    public void stopEffect(){
        effect.GetComponent<AudioSource>().loop = false;
        effect.GetComponent<AudioSource>().Stop();
    }

    [ButtonMethod]
    public void stopBackground(){
        background.GetComponent<AudioSource>().loop = false;
        background.GetComponent<AudioSource>().Stop();
    }

    [ButtonMethod]
    public void stopSFX(){
        sfx.GetComponent<AudioSource>().loop = false;
        sfx.GetComponent<AudioSource>().Stop();
    }
    
    [ButtonMethod]
    public void stopMusic(){
        music.GetComponent<AudioSource>().loop = false;
        music.GetComponent<AudioSource>().Stop();
    }

    [ButtonMethod]
    public void stopMaster(){
        master.GetComponent<AudioSource>().loop = false;
        master.GetComponent<AudioSource>().Stop();
    }

}
