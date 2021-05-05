using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectsMixer;

    public AudioSource arrow, hit, flame, potion, playerDeath, skeletonDeath, arrowGet, playerHit, bgMusic,
        bossDeath, bossHit, mainMenu;

    [Range(-80, 10)]
    public float masterVol, effectsVol;
    public Slider masterSlider, effectSlider;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        playAudio(bgMusic);
        //masterSlider.value = masterVol;
        //effectSlider.value = effectsVol;

        masterSlider.minValue = -80;
        masterSlider.maxValue = 10;

        effectSlider.minValue = -80;
        effectSlider.maxValue = 10;

        masterSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
        effectSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0);
    }

    void Update()
    {
        //masterVolume();
        //effectsVolume();
    }

    public void masterVolume()
    {
        DataManager.instance.musicData(masterSlider.value);
        musicMixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("musicVolume"));
    }

    public void effectsVolume()
    {
        DataManager.instance.SfxData(effectSlider.value);
        effectsMixer.SetFloat("effectsVolume", PlayerPrefs.GetFloat("sfxVolume"));
    }

    public void playAudio(AudioSource audio)
    {
        audio.Play();
    }
}
