using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectsMixer;

    public AudioSource arrow, hit, flame, potion, playerDeath, skeletonDeath, arrowGet, playerHit, bgMusic,
        bossDeath, bossHit;

    public float masterVol, effectsVol;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playAudio(bgMusic);
    }

    // Update is called once per frame
    void Update()
    {
        masterVolume();
        effectsVolume();
    }

    public void masterVolume()
    {
        musicMixer.SetFloat("masterVolume", masterVol);
    }

    public void effectsVolume()
    {
        effectsMixer.SetFloat("effectsVolume", effectsVol);
    }

    public void playAudio(AudioSource audio)
    {
        audio.Play();
    }
}
