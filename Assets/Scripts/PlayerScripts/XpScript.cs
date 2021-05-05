using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XpScript : MonoBehaviour
{
    public Image expImage;
    public int lvl;
    public float currentExperience;
    public float expTNL;
    public Text lvlString;

    public static XpScript instance;

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
        currentExperience = PlayerPrefs.GetFloat("experience", 0);
        lvl = PlayerPrefs.GetInt("level", 0);
        lvlString.text = lvl.ToString();
        expImage.fillAmount = currentExperience / expTNL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void expModifyer(float xp)
    {
        currentExperience += xp;
         
        expImage.fillAmount = currentExperience / expTNL;

        if (currentExperience >= expTNL)
        {
            lvl = lvl+1;
            lvlString.text = lvl.ToString();
            expTNL = expTNL * 2;
            currentExperience = 0;
        }
    }

    public void saveXp()
    {
        DataManager.instance.xpData(currentExperience);
        DataManager.instance.lvlData(lvl);
    }
}
