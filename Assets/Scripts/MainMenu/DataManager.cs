using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void musicData(float value)
    {
        PlayerPrefs.SetFloat("musicVolume", value);
    }

    public void SfxData(float value)
    {
        PlayerPrefs.SetFloat("sfxVolume", value);
    }

    public void arrowsData(int value)
    {
        PlayerPrefs.SetInt("arrowsAmount", value);
    }

    public void xpData(float value)
    {
        PlayerPrefs.SetFloat("experience", value);

    }

    public void lvlData(int value)
    {
        PlayerPrefs.SetInt("level", value);
    }

    public void playerHealthData(float value)
    {
        PlayerPrefs.SetFloat("playerHealth", value);
    }

    public void savePositionX(float value)
    {
        PlayerPrefs.SetFloat("playerX", value);
    }

    public void savePositionY(float value)
    {
        PlayerPrefs.SetFloat("playerY", value);
    }
}
