using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XpScript : MonoBehaviour
{
    public Image expImage;
    public float currentExperience;
    public float expTNL;

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
            expTNL = expTNL * 2;
            currentExperience = 0;
        }
    }
}
