using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "MainMenu")
        {
            AudioManager.instance.bgMusic.Stop();
            AudioManager.instance.playAudio(AudioManager.instance.mainMenu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Application closed!");
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void showSettings()
    {
        anim.SetBool("ShowSettings", true);
    }

    public void hideSettings()
    {
        anim.SetBool("ShowSettings", false);
    }
}
